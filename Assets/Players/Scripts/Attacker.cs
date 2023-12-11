using UnityEngine;

namespace Players
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        public void Shoot(Weapon weapon, Vector3 target) => 
            weapon.Shoot(_shootPoint, target);
    }
}