using UnityEngine;

namespace Enemies.StateMachine.States
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class Celebration : State
    {
        private EnemyAnimator _enemyAnimator;
        
        private void Awake() =>
            _enemyAnimator = GetComponent<EnemyAnimator>();

        private void OnEnable() =>
            _enemyAnimator.StartCelebration();
        
        private void OnDisable() =>
            _enemyAnimator.StopPlayback();
    }
}