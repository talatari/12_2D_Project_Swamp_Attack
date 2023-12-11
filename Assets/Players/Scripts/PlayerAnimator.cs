using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
    
        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void StartShoot() => 
            _animator.SetTrigger(AnimatorParameters.PlayerShoot);
    }
}