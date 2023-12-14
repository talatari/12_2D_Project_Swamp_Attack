using System;
using UnityEngine;

namespace Players
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private Transform _attackPoint;

        public event Action CantAttack;
        
        public void Attack(Weapon weapon, Vector3 target)
        {
            if (target.x < _attackPoint.position.x)
            {
                if (weapon.IsMeleeWeapon == false)
                    weapon.UseWeapon(_attackPoint, target);
                else
                    weapon.UseWeapon(_attackPoint);
                
                CantAttack?.Invoke();
            }
        }
    }
}