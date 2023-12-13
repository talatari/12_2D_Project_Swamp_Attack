using System;
using UnityEngine;

namespace Players
{
    public class Axe : Weapon
    {
        public override event Action UsedWeapon;

        public override void UseWeapon()
        {
            print("Use axe");
        }

        public override void UseWeapon(Transform shootPoint, Vector3 target) { }
    }
}