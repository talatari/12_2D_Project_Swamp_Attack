using Enemies;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speedBullet;

        private float _liveTime = 3f;
        private float _elapsedTime;
        private Rigidbody2D _rigidbody2D;
        private int _damage;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = transform.forward * _speedBullet;
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
    }
}