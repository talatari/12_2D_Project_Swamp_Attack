namespace Players
{
    public static class AnimatorParameters
    {
        public static readonly int PlayerIdle = UnityEngine.Animator.StringToHash(nameof(PlayerIdle));
        public static readonly int PlayerShoot = UnityEngine.Animator.StringToHash(nameof(PlayerShoot));
        public static readonly int PlayerDie = UnityEngine.Animator.StringToHash(nameof(PlayerDie));
    }
}