using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator _animator;
        
        public event Action OnSpawnProjectile;

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void StartAttack() => 
            _animator.SetTrigger(AnimatorParameters.Attack);
        
        public void StartCelebration() => 
            _animator.SetTrigger(AnimatorParameters.Celebration);
        
        public void StartDie() => 
            _animator.SetTrigger(AnimatorParameters.Die);

        public void StopPlayback() => 
            _animator.StartPlayback();
        
        public void SpawnProjectile() => 
            OnSpawnProjectile?.Invoke();
    }
}