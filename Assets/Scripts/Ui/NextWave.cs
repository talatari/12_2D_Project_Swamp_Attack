using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        _enemySpawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _enemySpawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnAllEnemySpawned() => 
        _nextWaveButton.gameObject.SetActive(true);

    private void OnNextWaveButtonClick()
    {
        _enemySpawner.NextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}