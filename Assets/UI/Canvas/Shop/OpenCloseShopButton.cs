using TMPro;
using UnityEngine;

namespace UI
{
    public class ShopInteract : MonoBehaviour
    {
        [SerializeField] private GameObject _shop;
        [SerializeField] private TextMeshProUGUI _coinsText;

        public void Interact() => 
            _shop.SetActive(!_shop.activeSelf);
    }
}