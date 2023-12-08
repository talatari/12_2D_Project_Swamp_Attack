using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemyWave
{
    public Enemy Prefab;
    public float Delay;
    public int Count;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyWave> _TypesEnemies;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private EnemyWave _currentEnemyWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start() => 
        SetWave(_currentWaveNumber);

    private void Update()
    {
        if (_currentEnemyWave is null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentEnemyWave.Delay)
        {
            Spawn();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentEnemyWave.Count);
        }

        if (_currentEnemyWave.Count <= _spawned)
        {
            if (_TypesEnemies.Count >= _currentWaveNumber + 1)
                AllEnemySpawned?.Invoke();

            _currentEnemyWave = null;
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_currentEnemyWave.Prefab, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentEnemyWave = _TypesEnemies[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    public void NextWave()
    {
        SetWave(_currentWaveNumber++);
        _spawned = 0;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
    }
}