using System.Collections.Generic;
using Players;
using UnityEngine;

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

        private void Start() => 
            SetWave(_currentWaveNumber);

        private void Update()
        {
            if (_currentWave == null)
                return;

            _timeAfterLastSpawn += Time.deltaTime;
            
            if (_timeAfterLastSpawn > _currentWave.Delay)
            {
                Spawn();

                _countSpawned++;
                _timeAfterLastSpawn = 0;
            }

            if (_countSpawned == _currentWave.Count)
            {
                _countSpawned = 0;
                _currentWave = null;
            }
        }

        private void SetWave(int index) => 
            _currentWave = _waves[index];

        private void Spawn()
        {
            Transform spawnPoint = GetSpawnPoint();
            Enemy enemy = Instantiate(_currentWave.EnemyPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            enemy.Init(_player);
            enemy.EnemyDie += OnEnemyDie;
            _enemies.Enqueue(enemy);
        }

        private void OnEnemyDie(Enemy enemy)
        {
            enemy.EnemyDie -= OnEnemyDie;
            _enemies.Dequeue();
            
            TryRunNextWave();
        }

        private void TryRunNextWave()
        {
            if (_enemies.Count == 0 && _currentWave == null)
                if (_currentWaveNumber < _waves.Count - 1)
                    SetWave(++_currentWaveNumber);
        }

        private Transform GetSpawnPoint() => 
            _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }
}