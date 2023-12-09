using System;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(UnityEngine.Animator))]
    public class Animator : MonoBehaviour
    {
        private UnityEngine.Animator _animator;
    
        public event Action AttackAnimationEnd;

        private void Awake() => 
            _animator = GetComponent<UnityEngine.Animator>();

        public void StartAttack() => 
            _animator.SetBool(AnimatorParameters.Attack, true);

        public void StopAttack() => 
            _animator.SetBool(AnimatorParameters.Attack, false);
    
        public void AttackAnimationEnded() => 
            AttackAnimationEnd?.Invoke();
    }
}