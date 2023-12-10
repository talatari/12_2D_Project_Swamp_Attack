using UnityEngine;

namespace Players
{
    public class Shotgun : Weapon
    {
        private Vector3[] _offsets = { new (10, -3, 0), new (0, -6, 0), new (-3, 4, 0), new (-5, 2, 0) }; 
        
        public override Bullet[] Shoot(Transform shootPoint, Vector3 target)
        {
            Bullet[] bullets = { };
            Vector3 position = shootPoint.position;

            for (int i = 0; i < _offsets.Length; i++)
            {
                bullets[i] = Instantiate(Bullet, position + _offsets[i], Quaternion.identity);
                bullets[i].SetTargetPosition(target);
            }

            return bullets;
        }
    }
}