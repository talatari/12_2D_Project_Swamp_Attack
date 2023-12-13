using System;
using Players;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private Button _sellButton;
        
        private Weapon _weapon;

        public event Action<Weapon, WeaponView> SellButtonClick; 

        private void OnEnable()
        {
            _sellButton.onClick.AddListener(SellWeapon);
            _sellButton.onClick.AddListener(TryLockWeapon);
        }

        private void OnDisable()
        {
            _sellButton.onClick.RemoveListener(SellWeapon);
            _sellButton.onClick.RemoveListener(TryLockWeapon);
        }

        public void Render(Weapon weapon)
        {
            _weapon = weapon;
            _image.sprite = weapon.Sprite;
            _title.text = weapon.Title;
            _price.text = weapon.Price.ToString();
        }

        private void SellWeapon() => 
            SellButtonClick?.Invoke(_weapon, this);

        private void TryLockWeapon()
        {
            if (_weapon.IsBuyed)
                _sellButton.interactable = false;
        }
    }
}