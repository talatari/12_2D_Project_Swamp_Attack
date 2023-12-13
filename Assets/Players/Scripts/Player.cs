using System;
using System.Collections.Generic;
using UI;
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
        private PlayerHealthBar _playerHealthBar;
        private Coins _coins;
        private OnOffSounds _onOffSounds;
        private bool _canShoot = true;
        private bool _canPlaySounds = true;

        public event Action PlayerDie;

        public int Coins => _wallet.Coins;
        
        private void Awake()
        {
            _health = GetComponent<Health>();
            _attacker = GetComponent<Attacker>();
            _wallet = GetComponent<Wallet>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            
            _rayCaster = FindObjectOfType<RayCaster>();
            _playerHealthBar = FindObjectOfType<PlayerHealthBar>();
            _coins = FindObjectOfType<Coins>();
            _onOffSounds = FindObjectOfType<OnOffSounds>();
            
            _currentWeapon = _weapons[_weapons.Count - 1];
        }

        private void OnEnable()
        {
            _health.PlayerDie += OnPlayerDie;
            _health.HealthChanged += OnHealthChanged;
            _attacker.CantShoot += OnCantShoot;
            _wallet.CoinsChanged += OnCoinsChanged;
            _rayCaster.HaveTarget += OnShoot;
            _onOffSounds.SwithSounds += OnSetPlaySounds;
            _currentWeapon.UsedWeapon += OnCanShoot;
        }

        private void OnPlayerDie()
        {
            PlayerDie?.Invoke();
            
            _health.PlayerDie -= OnPlayerDie;
            _health.HealthChanged -= OnHealthChanged;
            _attacker.CantShoot -= OnCantShoot;
            _wallet.CoinsChanged -= OnCoinsChanged;
            _rayCaster.HaveTarget -= OnShoot;
            _onOffSounds.SwithSounds -= OnSetPlaySounds;
            _currentWeapon.UsedWeapon -= OnCanShoot;
            
            _playerAnimator.StartDeathWithGun();
        }

        public void TakeDamage(int damage) =>
            _health.TakeDamage(damage);

        public void GiveReward(int coins) => 
            _wallet.AddCoins(coins);

        public void BuyWeapon(Weapon weapon)
        {
            _wallet.SpendCoins(weapon.Price);
            _weapons.Add(weapon);
        }
        
        public void SetCantShoot() => 
            _canShoot = _canShoot ? false : true;

        private void OnSetPlaySounds() => 
            _canPlaySounds = _canPlaySounds ? false : true;

        private void OnHealthChanged(int currentHealth, int maxHealth) => 
            _playerHealthBar.RefreshHealthBar(currentHealth, maxHealth);

        private void OnCoinsChanged(int coins) => 
            _coins.RefreshCoinsText(coins);

        private void OnCantShoot()
        {
            _playerAnimator.StartShoot();

            if (_canPlaySounds)
            {
                if (_soundShoot != null)
                    _soundShoot.Play();
                
                if (_soundReloadGun != null)
                    _soundReloadGun?.Play();
            }
            
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