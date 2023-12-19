using UnityEngine;

namespace Enemies
{
    public static class AnimatorParameters
    {
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int Die = Animator.StringToHash(nameof(Die));
        public static readonly int Celebration = Animator.StringToHash(nameof(Celebration));
    }
}