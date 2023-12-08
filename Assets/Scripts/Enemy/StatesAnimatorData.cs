using UnityEngine;

public static class StatesAnimatorData
{
    public static class Params
    {
        public static readonly int Celebration = Animator.StringToHash(nameof(Celebration));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
    }
}