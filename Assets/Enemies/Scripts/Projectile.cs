using Players;
using UnityEngine;

namespace Enemies
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private int _damage;
        private Player _player;
        private Vector3 _offsetCenterTarget = new (0, 0.5f, 0);
        
        public void Init(int damage, Player player)
        {
            _damage = damage;
            _player = player;
        }

        private void Update()
        {
            if (_player != null)
                transform.position = Vector3.MoveTowards(
                    transform.position, _player.transform.position + _offsetCenterTarget, _speed * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out Player player))
            {
                player.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}