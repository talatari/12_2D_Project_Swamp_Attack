using TMPro;
using UnityEngine;

namespace UI
{
    public class OpenCloseShopButton : MonoBehaviour
    {
        [SerializeField] private GameObject _shop;

        public void OpenCloseShop() => 
            _shop.SetActive(!_shop.activeSelf);
    }
}