using System;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
    
        public event Action AttackAnimationEnd;

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void StartShoot() => 
            _animator.SetTrigger(AnimatorParameters.PlayerShoot);

        public void ShootAnimationEnded() => 
            AttackAnimationEnd?.Invoke();
    }
}