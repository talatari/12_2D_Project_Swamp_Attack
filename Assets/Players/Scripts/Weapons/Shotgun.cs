using UnityEngine;

namespace Players
{
    public class Shotgun : Weapon
    {
        private Vector2[] _offsets = { new (-0.5f, -0.1f), new (0.1f, -0.4f), new (0.0f, 0.4f), new (0.3f, 0.1f) };
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
                        Quaternion rotation = Quaternion.LookRotation(target - position);
                        Bullet bullet = Instantiate(Bullet, position, Quaternion.Euler(rotation));
                        bullet.SetTargetPosition(target + _offsets[i]);
                    }
                    
                    // Angle - угол поворота в радианах
                    // Axis - ось вращения (например, Vector3.up или Vector3.right)
                    // var rotation = Quaternion.LookRotation(target - position);
                    // var newRotation = Quaternion.Slerp(Quaternion.identity, rotation, 5 * Time.deltaTime);
                    // transform.rotation = newRotation;
                }
            }
        }
    }
}