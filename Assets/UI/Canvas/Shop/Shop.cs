using System.Collections.Generic;
using Players;
using UnityEngine;

namespace UI
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weaponPrefabs;
        [SerializeField] private Player _player;
        [SerializeField] private WeaponView _weaponViewPrefab;
        [SerializeField] private GameObject _weaponContainer;

        private void Start()
        {
            for (int i = 0; i < _weaponPrefabs.Count; i++)
                AddWeaponPrefabs(_weaponPrefabs[i]);
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
            _player.SetCantAttack();
            _player.UnsubscribeRayCaster();
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            _player.SetCantAttack();
            _player.SubscribeRayCaster();
        }

        private void AddWeaponPrefabs(Weapon weaponPrefab)
        {
            WeaponView weaponView = Instantiate(_weaponViewPrefab, _weaponContainer.transform);
            weaponView.Render(weaponPrefab);
            weaponView.SellButtonClick += OnSellButtonClick;
        }

        private void OnSellButtonClick(Weapon weaponPrefab, WeaponView weaponView) => 
            TrySellWeapon(weaponPrefab, weaponView);

        private void TrySellWeapon(Weapon weaponPrefab, WeaponView weaponView)
        {
            if (weaponPrefab.Price <= _player.Coins)
            {
                Weapon weapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
                _player.BuyWeapon(weapon);
                
                weaponPrefab.Buy();
                weaponView.SellButtonClick -= OnSellButtonClick;
            }
        }
    }
}