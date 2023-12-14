using System;
using UnityEngine;

namespace Players
{
    public class Shotgun : Weapon
    {
        private Vector3[] _offsets = { 
            new (-0.5f, -0.1f, 0.0f), new (0.1f, -0.4f, 0.0f), new (0.0f, 0.4f, 0.0f), new (0.3f, 0.1f, 0.0f) };
        private float _elapsedTime;
        private float _attackDelayDone = 0.1f;
        
        public override event Action CanUseWeapon;

        private void Update()
        {
            _elapsedTime -= Time.deltaTime;
            
            if (_elapsedTime < _attackDelayDone)
                CanUseWeapon?.Invoke();
        }

        public override void UseWeapon(Transform shootPoint, Vector3 target)
        {
            if (_elapsedTime < _attackDelayDone)
            {
                _elapsedTime = AttackDelay;
                Vector3 position = shootPoint.position;
                
                for (var i = 0; i < _offsets.Length; i++)
                {
                    Bullet bullet = Instantiate(BulletPrefab, position, Quaternion.identity);
                    bullet.SetDamage(Damage);
                    bullet.SetTargetPosition(target + _offsets[i]);
                }
            }
        }
        
        public override void UseWeapon(Transform shootPoint) { }
    }
}