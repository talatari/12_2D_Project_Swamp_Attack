using UnityEngine;

namespace UI.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private GameObject _shop;

        public void Interact() => 
            _shop.SetActive(!_shop.activeSelf);
    }
}