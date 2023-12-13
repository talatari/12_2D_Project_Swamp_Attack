using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tmpText;
        [SerializeField] private Image _fillBar;
        [SerializeField] private Gradient _gradient;
        
        public void RefreshHealthBar(int currentHealth, int maxHealth)
        {
            _tmpText.text = currentHealth + " / " + maxHealth;
            _fillBar.fillAmount = (float) currentHealth / maxHealth;
            _fillBar.color = _gradient.Evaluate(_fillBar.fillAmount);
        }
    }
}