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
            _rayCaster.HaveTarget += OnShoot;
            _currentWeapon.ShootedWeapon += OnCanShoot;
        }

        private void OnPlayerDie()
        {
            PlayerDie?.Invoke();
            
            _health.PlayerDie -= OnPlayerDie;
            _rayCaster.HaveTarget -= OnShoot;
            _currentWeapon.ShootedWeapon -= OnCanShoot;
            
            _playerAnimator.StartDeathWithGun();
        }

        public void TakeDamage(int damage) =>
            _health.TakeDamage(damage);

        public void GiveReward(int coins) => 
            _wallet.AddCoins(coins);

        private void OnShoot(Vector3 target)
        {
            if (_canShoot)
            {
                _playerAnimator.StartShoot();
                _attacker.Shoot(_currentWeapon, target);
                _canShoot = false;
            }
        }

        private void OnCanShoot() => 
            _canShoot = true;
    }
}