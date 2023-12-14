using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class Attack : State
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDelay;
        [SerializeField] private Projectile _projectilePrefab;
        
        private float _lastAttackTime;
        private EnemyAnimator _enemyAnimator;
        
        private void Awake() => 
            _enemyAnimator = GetComponent<EnemyAnimator>();

        private void OnEnable() => 
            _enemyAnimator.OnSpawnProjectile += OnSpawnProjectile;

        private void OnDisable() => 
            _enemyAnimator.OnSpawnProjectile -= OnSpawnProjectile;

        private void Update()
        {
            if (_lastAttackTime <= 0)
            {
                AttackPlayer();
                _lastAttackTime = _attackDelay;
            }
            
            _lastAttackTime -= Time.deltaTime;
        }

        private void AttackPlayer() => 
            _enemyAnimator.StartAttack();

        private void OnSpawnProjectile()
        {
            Vector3 _startPositionProjectile = new Vector3(3.0f, 0.8f, 0) + transform.position;
            Projectile projectile = Instantiate(_projectilePrefab, _startPositionProjectile, Quaternion.identity);
            projectile.Init(_damage, Player);
            projectile.transform.SetParent(transform);
        }
    }
}