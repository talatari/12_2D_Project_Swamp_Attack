using TMPro;
using UnityEngine;

namespace UI.Shop
{
    public class ShopInteract : MonoBehaviour
    {
        [SerializeField] private GameObject _shop;
        [SerializeField] private TextMeshProUGUI _coinsText;

        public void Interact() => 
            _shop.SetActive(!_shop.activeSelf);
    }
}