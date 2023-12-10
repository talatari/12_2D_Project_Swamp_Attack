using Enemies;
using UnityEngine;

namespace Players
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private Transform _shootPoint;

        public void Shoot(Weapon weapon, Vector2 target) => 
            weapon.Shoot(_shootPoint, target);

        public void PlayerGiveDamage(Enemy enemy)
        {
            if (enemy is not null)
                enemy.TakeDamage(_damage);
        }
    }
}