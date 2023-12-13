using Players;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WeaponSlots : MonoBehaviour
    {
        [SerializeField] private GameObject _firstSlot;
        [SerializeField] private Image _firstSlotImage;
        [SerializeField] private GameObject _secondSlot;
        [SerializeField] private Image _secondSlotImage;
        
        private Player _player;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
            _player.WeaponsChanged += OnLoadWeapons;
            OnLoadWeapons();
        }

        private void OnDisable() => 
            _player.WeaponsChanged -= OnLoadWeapons;

        public void OnFirstSlotClick()
        {
            if (_player.Weapons.Count > 0)
                _player.SwapWeapons(0);
        }
        
        public void OnSecondSlotClick()
        {
            if (_player.Weapons.Count > 1)
                _player.SwapWeapons(1);
        }
        
        private void OnLoadWeapons()
        {
            if (_player.Weapons.Count > 0)
            {
                _firstSlot.SetActive(true);
                _firstSlotImage.sprite = _player.CurrentWeapon.Sprite;
            }

            if (_player.Weapons.Count > 1)
            {
                _secondSlot.SetActive(true);
                _secondSlotImage.sprite = _player.Weapons[1].Sprite;
            }
        }
    }
}