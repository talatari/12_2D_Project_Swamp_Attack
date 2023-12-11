using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void StartAttack() => 
            _animator.SetTrigger(AnimatorParameters.EnemyAttack);
        
        public void StartCelebration() => 
            _animator.SetTrigger(AnimatorParameters.EnemyCelebration);

        public void StopPlayback() => 
            _animator.StartPlayback();
    }
}