using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        enemySpawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        enemySpawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    public void OnAllEnemySpawned() => 
        _nextWaveButton.gameObject.SetActive(true);

    public void OnNextWaveButtonClick()
    {
        enemySpawner.NextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}