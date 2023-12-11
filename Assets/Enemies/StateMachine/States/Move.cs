using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class Move : State
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            if (Player is not null)
                transform.position = Vector2.MoveTowards(
                    transform.position, Player.transform.position, _speed * Time.deltaTime);
        }
    }
}