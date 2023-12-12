using UnityEngine;

namespace Enemies
{
    public class Move : State
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            if (Player != null)
                transform.position = Vector2.MoveTowards(
                    transform.position, Player.transform.position, _speed * Time.deltaTime);
        }
    }
}