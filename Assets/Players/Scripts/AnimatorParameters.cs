namespace Players
{
    public static class AnimatorParameters
    {
        public static readonly int PlayerShootGun = UnityEngine.Animator.StringToHash(nameof(PlayerShootGun));
        public static readonly int PlayerReloadGun = UnityEngine.Animator.StringToHash(nameof(PlayerReloadGun));
        public static readonly int PlayerGunToAxe = UnityEngine.Animator.StringToHash(nameof(PlayerGunToAxe));
        public static readonly int PlayerAxeToGun = UnityEngine.Animator.StringToHash(nameof(PlayerAxeToGun));
        public static readonly int PlayerAttackAxe = UnityEngine.Animator.StringToHash(nameof(PlayerAttackAxe));
        public static readonly int PlayerDie = UnityEngine.Animator.StringToHash(nameof(PlayerDie));
    }
}