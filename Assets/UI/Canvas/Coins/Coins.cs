using TMPro;
using UnityEngine;

namespace UI
{
    public class Coins : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        public void RefreshCoinsText(int coins)
        {
            if (coins >= 0) 
                _coinsText.text = coins.ToString();
        }
    }
}