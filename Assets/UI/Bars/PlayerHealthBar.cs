using Players;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private Image _fillBar;
        [SerializeField] private Gradient _gradient;
        
        private Health _playerHealth;

        private void Awake()
        {
            _playerHealth = FindObjectOfType<Health>();
            _playerHealth.HealthChanged += OnRefreshHealthBar;
        }

        private void OnDestroy() => 
            _playerHealth.HealthChanged -= OnRefreshHealthBar;

        private void OnRefreshHealthBar(int currentHealth, int maxHealth)
        {
            _tmpText.text = currentHealth + " / " + maxHealth;
            _fillBar.fillAmount = (float) currentHealth / maxHealth;
            _fillBar.color = _gradient.Evaluate(_fillBar.fillAmount);
        }
    }
}