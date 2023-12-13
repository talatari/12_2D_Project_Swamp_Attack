using System.Collections.Generic;
using Players;
using UnityEngine;

namespace UI
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private Player _player;
        [SerializeField] private WeaponView _weaponViewPrefab;
        [SerializeField] private GameObject _weaponContainer;

        private void Start()
        {
            for (int i = 0; i < _weapons.Count; i++)
                AddWeapon(_weapons[i]);
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
            _player.SetCantShoot();
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            _player.SetCantShoot();
        }

        private void AddWeapon(Weapon weapon)
        {
            WeaponView weaponView = Instantiate(_weaponViewPrefab, _weaponContainer.transform);
            weaponView.Render(weapon);
        }

        private void OnSellButtonClick(Weapon weapon, WeaponView weaponView) => 
            TrySellWeapon(weapon, weaponView);

        private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
        {
            if (weapon.Price <= _player.Coins)
            {
                _player.BuyWeapon(weapon);
                weapon.Buy();
            }
        }
    }
}