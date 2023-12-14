using Enemies;
using UnityEngine;

namespace Players.Prefabs.Weapons.Axe
{
    public class AxeBlade : MonoBehaviour
    {
        private int _damage;

        private void Start() => 
            Destroy(gameObject, 1f);

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