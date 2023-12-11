using Enemies;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speedBullet;

        private float _liveTime = 1f;
        private float _elapsedTime;
        private Rigidbody2D _rigidbody2D;
        private int _damage;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            Destroy(gameObject, _liveTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }

        public void SetDamage(int damage) => 
            _damage = damage;

        public void SetTargetPosition(Vector3 targetPosition) => 
            _rigidbody2D.velocity = (Vector2) (targetPosition - transform.position).normalized * _speedBullet;
    }
}