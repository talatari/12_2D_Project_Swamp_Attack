using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private EnemySpawner enemySpawner;

    private void OnEnable()
    {
        enemySpawner.EnemyCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable() => 
        enemySpawner.EnemyCountChanged -= OnValueChanged;
}