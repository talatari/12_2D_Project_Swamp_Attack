using UnityEngine;

namespace Players
{
    public class Shotgun : Weapon
    {
        private Vector3[] _offsets = { new (1, -1, 0), new (0, -1, 0), new (-1, 1, 0), new (-1, 1, 0) };
        
        private float _elapsedTime;

        private void Update() => 
            _elapsedTime -= Time.deltaTime;

        public override void Shoot(Transform shootPoint, Vector3 target)
        {
            if (_elapsedTime <= 0.1f)
            {
                _elapsedTime = SpeedShoot;
                Vector3 position = shootPoint.position;

                if (target.x < position.x)
                {
                    for (int i = 0; i < _offsets.Length; i++)
                    {
                        // x: -1.175, y: -0.535
                        Bullet bullet = Instantiate(Bullet, position + _offsets[i], Quaternion.identity);
                        bullet.SetTargetPosition(target);
                    }
                }
            }
        }
    }
}