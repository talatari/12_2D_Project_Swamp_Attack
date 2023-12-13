using UnityEngine;

namespace UI
{
    public class OpenCloseShopButton : MonoBehaviour
    {
        [SerializeField] private GameObject _shop;

        public void OpenClose()
        {
            // _shop.SetActive(!_shop.activeSelf);
            
            if (_shop.activeSelf)
                _shop.SetActive(false);
            else
                _shop.SetActive(true);
        }
    }
}