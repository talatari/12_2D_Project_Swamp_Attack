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
            _animator.SetTrigger(AnimatorParameters.ShootGun);

        public void StartAttackAxe() =>
            _animator.SetTrigger(AnimatorParameters.AttackAxe);

        public void StartDeathWithGun() =>
            _animator.SetTrigger(AnimatorParameters.DeathWithGun);

        public void StartDeathWithAxe() =>
            _animator.SetTrigger(AnimatorParameters.DeathWithAxe);

        public void StartGunToAxe() =>
            _animator.SetTrigger(AnimatorParameters.GunToAxe);

        public void StartAxeToGun() =>
            _animator.SetTrigger(AnimatorParameters.AxeToGun);
    }
}