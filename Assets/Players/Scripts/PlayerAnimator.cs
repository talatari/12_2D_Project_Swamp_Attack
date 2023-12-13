using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
    
        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void StartShootGun() => 
            _animator.SetTrigger(AnimatorParameters.PlayerShootGun);

        public void StartAttackAxe() =>
            _animator.SetTrigger(AnimatorParameters.PlayerAttackAxe);

        public void StartDeathWithGun() =>
            _animator.SetTrigger(AnimatorParameters.PlayerDeathWithGun);

        public void StartDeathWithAxe() =>
            _animator.SetTrigger(AnimatorParameters.PlayerDeathWithAxe);

        public void StartGunToAxe() =>
            _animator.SetTrigger(AnimatorParameters.PlayerGunToAxe);

        public void StartAxeToGun() =>
            _animator.SetTrigger(AnimatorParameters.PlayerAxeToGun);
    }
}