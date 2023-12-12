using System;
using UnityEngine;

namespace Players
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        public event Action CantShoot;
        
        public void Shoot(Weapon weapon, Vector3 target)
        {
            if (target.x < _shootPoint.position.x)
            {
                weapon.Shoot(_shootPoint, target);
                
                CantShoot?.Invoke();
            }
        } 
    }
}