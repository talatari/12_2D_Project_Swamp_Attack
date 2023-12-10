using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Health), typeof(Animator))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;

        private Health _health;
        private Weapon _currentWeapon;
        private Attacker _attacker;
        private Animator _animator;
        private Enemy _currentTarget;
        private RayCaster _rayCaster;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _animator = GetComponent<Animator>();
            _rayCaster = FindObjectOfType<RayCaster>();
            _currentWeapon = _weapons[_weapons.Count - 1];
        }

        private void OnEnable()
        {
            _health.PlayerDestroy += OnDestroy;
            _rayCaster.HaveTarget += OnShoot;
        }

        private void OnDisable()
        {
            _health.PlayerDestroy -= OnDestroy;
            _rayCaster.HaveTarget -= OnShoot;
        }

        private void OnDestroy() => 
            Destroy(gameObject);

        public void TakeDamage(int damage) =>
            _health.TakeDamage(damage);

        public void GiveDamage() => 
            _attacker.PlayerGiveDamage(_currentTarget);

        private void OnShoot(Vector3 target) => 
            _attacker.Shoot(_currentWeapon, target);
    }
}