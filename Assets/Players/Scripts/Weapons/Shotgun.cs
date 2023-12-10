using UnityEngine;

namespace Players
{
    public class Shotgun : Weapon
    {
        private Vector3[] _offsets = { 
            new (-0.5f, -0.1f, 0.0f), new (0.1f, -0.4f, 0.0f), new (0.0f, 0.4f, 0.0f), new (0.3f, 0.1f, 0.0f) };
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
                    for (int i = 0; i < _offsets.Length; i++)
                    {
                        Bullet bullet = Instantiate(Bullet, position, Quaternion.identity);
                        bullet.SetTargetPosition(target + _offsets[i]);
                    }
            }
        }
    }
}