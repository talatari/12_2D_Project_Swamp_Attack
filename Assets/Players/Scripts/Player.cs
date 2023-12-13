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
        private bool _canAttack = true;
        private bool _canPlaySounds = true;

        public event Action PlayerDie;
        public event Action WeaponsChanged;

        public int Coins => _wallet.Coins;
        public Weapon CurrentWeapon => _currentWeapon;
        public List<Weapon> Weapons => _weapons;
        
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
            _attacker.CantAttack += OnCantAttack;
            _wallet.CoinsChanged += OnCoinsChanged;
            _rayCaster.HaveTarget += OnAttack;
            _onOffSounds.SwithSounds += OnSetPlaySounds;
            _currentWeapon.UsedWeapon += OnCanAttack;
        }

        private void OnPlayerDie()
        {
            PlayerDie?.Invoke();
            
            _health.PlayerDie -= OnPlayerDie;
            _health.HealthChanged -= OnHealthChanged;
            _attacker.CantAttack -= OnCantAttack;
            _wallet.CoinsChanged -= OnCoinsChanged;
            _rayCaster.HaveTarget -= OnAttack;
            _onOffSounds.SwithSounds -= OnSetPlaySounds;
            _currentWeapon.UsedWeapon -= OnCanAttack;
            
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
            
            WeaponsChanged?.Invoke();
        }
        
        public void SetCantAttack() => 
            _canAttack = _canAttack ? false : true;

        public void SwapWeapons(int index)
        {
            _currentWeapon = _weapons[index];

            if (index == 0)
                _playerAnimator.StartAxeToGun();
            
            if (index == 1)
                _playerAnimator.StartGunToAxe();
        }

        private void OnSetPlaySounds() => 
            _canPlaySounds = _canPlaySounds ? false : true;

        private void OnHealthChanged(int currentHealth, int maxHealth) => 
            _playerHealthBar.RefreshHealthBar(currentHealth, maxHealth);

        private void OnCoinsChanged(int coins) => 
            _coins.RefreshCoinsText(coins);

        private void OnCantAttack()
        {
            // TODO: переписать этот колхоз

            if (_canPlaySounds && _currentWeapon == _weapons[0])
            {
                _playerAnimator.StartShootGun();
                
                if (_soundShoot != null)
                    _soundShoot.Play();
                
                if (_soundReloadGun != null)
                    _soundReloadGun?.Play();
            }

            if (_weapons.Count > 1 && _currentWeapon == _weapons[1])
                _playerAnimator.StartAttackAxe();

            _canAttack = false;
        }

        private void OnAttack(Vector3 target)
        {
            if (_canAttack)
                _attacker.Attack(_currentWeapon, target);
        }

        private void OnCanAttack() => 
            _canAttack = true;
    }
}