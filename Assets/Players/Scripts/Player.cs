using System;
using System.Collections.Generic;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Health), typeof(PlayerAnimator))]
    [RequireComponent(typeof(Wallet), typeof(Attacker))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private AudioSource _soundShoot;
        [SerializeField] private AudioSource _soundReloadGun;

        private Health _health;
        private Weapon _currentWeapon;
        private Attacker _attacker;
        private Wallet _wallet;
        private PlayerAnimator _playerAnimator;
        private RayCaster _rayCaster;
        private bool _canShoot = true;

        public event Action PlayerDie;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _attacker = GetComponent<Attacker>();
            _wallet = GetComponent<Wallet>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _rayCaster = FindObjectOfType<RayCaster>();
            _currentWeapon = _weapons[_weapons.Count - 1];
        }

        private void OnEnable()
        {
            _health.PlayerDie += OnPlayerDie;
            _attacker.CantShoot += OnCantShoot;
            _rayCaster.HaveTarget += OnShoot;
            _currentWeapon.ShootedWeapon += OnCanShoot;
        }

        private void OnPlayerDie()
        {
            PlayerDie?.Invoke();
            
            _health.PlayerDie -= OnPlayerDie;
            _attacker.CantShoot -= OnCantShoot;
            _rayCaster.HaveTarget -= OnShoot;
            _currentWeapon.ShootedWeapon -= OnCanShoot;
            
            _playerAnimator.StartDeathWithGun();
        }

        public void TakeDamage(int damage) =>
            _health.TakeDamage(damage);

        public void GiveReward(int coins) => 
            _wallet.AddCoins(coins);

        private void OnCantShoot()
        {
            _playerAnimator.StartShoot();
                
            if (_soundShoot != null)
                _soundShoot.Play();
                
            if (_soundReloadGun != null)
                _soundReloadGun?.Play();
            
            _canShoot = false;
        }

        private void OnShoot(Vector3 target)
        {
            if (_canShoot)
                _attacker.Shoot(_currentWeapon, target);
        }

        private void OnCanShoot() => 
            _canShoot = true;
    }
}