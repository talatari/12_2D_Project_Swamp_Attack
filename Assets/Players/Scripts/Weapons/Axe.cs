using System;
using UnityEngine;

namespace Players
{
    public class Axe : Weapon
    {
        private float _elapsedTime;
        private float _attackDelayDone = 0.1f;

        public override event Action CanUseWeapon;

        private void Update()
        {
            _elapsedTime -= Time.deltaTime;

            if (_elapsedTime < _attackDelayDone)
                CanUseWeapon?.Invoke();
        }
        
        public override void UseWeapon()
        {
            if (_elapsedTime < _attackDelayDone)
            {
                _elapsedTime = AttackDelay;
                
                
            }
        }

        public override void UseWeapon(Transform shootPoint, Vector3 target) { }
    }
}