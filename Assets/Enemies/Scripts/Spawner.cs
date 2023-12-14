using System;
using System.Collections.Generic;
using Players;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private List<Wave> _waves;
        [SerializeField] private Transform[] _spawnPoints;

        private Queue<Enemy> _enemies = new ();
        private Wave _currentWave;
        private int _currentWaveNumber = 0;
        private int _countSpawned;
        private float _timeAfterLastSpawn;

        public event Action<int, int> WaveChanged;
        public event Action<int> WaveStarted;
        
        private void Start() => 
            StartWave(_currentWaveNumber);

        private void Update()
        {
            if (_currentWave == null)
                return;

            _timeAfterLastSpawn += Time.deltaTime;
            
            if (_timeAfterLastSpawn > _currentWave.Delay)
            {
                _countSpawned++;
                
                Spawn();
                
                _timeAfterLastSpawn = 0;
            }

            if (_countSpawned == _currentWave.Count)
            {
                _countSpawned = 0;
                _currentWave = null;
            }
        }

        private void StartWave(int index)
        {
            _currentWave = _waves[index];
            WaveStarted?.Invoke(index + 1);
        }

        private void Spawn()
        {
            Transform spawnPoint = GetSpawnPoint();
            Enemy enemy = Instantiate(_currentWave.EnemyPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            enemy.name = "Enemy" + enemy.GetInstanceID();
            enemy.Init(_player);
            enemy.EnemyDie += OnEnemyDie;
            
            _enemies.Enqueue(enemy);
            WaveChanged?.Invoke(_enemies.Count, _waves[_currentWaveNumber].Count);
        }

        private void OnEnemyDie(Enemy enemy)
        {
            enemy.EnemyDie -= OnEnemyDie;
            
            _enemies.Dequeue();
            WaveChanged?.Invoke(_enemies.Count, _waves[_currentWaveNumber].Count);

            TryRunNextWave();
        }

        private void TryRunNextWave()
        {
            if (_enemies.Count == 0 && _currentWave == null)
                if (_currentWaveNumber < _waves.Count - 1)
                    StartWave(++_currentWaveNumber);
        }

        private Transform GetSpawnPoint() => 
            _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }
}