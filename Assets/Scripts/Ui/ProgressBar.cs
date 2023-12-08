using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private void OnEnable()
    {
        _enemySpawner.EnemyCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable() => 
        _enemySpawner.EnemyCountChanged -= OnValueChanged;
}