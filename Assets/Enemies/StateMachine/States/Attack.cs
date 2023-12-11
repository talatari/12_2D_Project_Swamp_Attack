using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class Attack : State
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDelay;
        
        private float _lastAttackTime;
        private EnemyAnimator _enemyAnimator;

        private void Awake() => 
            _enemyAnimator = GetComponent<EnemyAnimator>();

        private void Update()
        {
            if (_lastAttackTime <= 0)
            {
                AttackPlayer();
                _lastAttackTime = _attackDelay;
            }
            
            _lastAttackTime -= Time.deltaTime;
        }

        private void AttackPlayer()
        {
            _enemyAnimator.StartAttack();
            Player.TakeDamage(_damage);
        }
    }
}