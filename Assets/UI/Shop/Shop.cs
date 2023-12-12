using TMPro;
using UnityEngine;

namespace UI.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private GameObject _shop;
        [SerializeField] private TextMeshProUGUI _coinsText;

        private void Awake()
        {
            
        }

        public void Interact() => 
            _shop.SetActive(!_shop.activeSelf);
    }
}