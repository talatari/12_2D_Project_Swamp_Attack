using UnityEngine;

namespace Players
{
    public static class AnimatorParameters
    {
        public static readonly int ShootGun = Animator.StringToHash(nameof(ShootGun));
        public static readonly int GunToAxe = Animator.StringToHash(nameof(GunToAxe));
        public static readonly int AxeToGun = Animator.StringToHash(nameof(AxeToGun));
        public static readonly int AttackAxe = Animator.StringToHash(nameof(AttackAxe));
        public static readonly int DeathWithGun = Animator.StringToHash(nameof(DeathWithGun));
        public static readonly int DeathWithAxe = Animator.StringToHash(nameof(DeathWithAxe));
    }
}