namespace Enemies
{
    public static class AnimatorParameters
    {
        public static readonly int EnemyMove = UnityEngine.Animator.StringToHash(nameof(EnemyMove));
        public static readonly int EnemyAttack = UnityEngine.Animator.StringToHash(nameof(EnemyAttack));
        public static readonly int EnemyDie = UnityEngine.Animator.StringToHash(nameof(EnemyDie));
        public static readonly int EnemyCelebration = UnityEngine.Animator.StringToHash(nameof(EnemyCelebration));
    }
}