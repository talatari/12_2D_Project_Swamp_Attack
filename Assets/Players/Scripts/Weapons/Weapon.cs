using UnityEngine;

namespace Players
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private string _title;
        [SerializeField] private int _damage;
        [SerializeField] private int _speedShoot;
        [SerializeField] private int _price;
        [SerializeField] private bool _isBuyed;
        [SerializeField] private Sprite _icon;
        [SerializeField] protected Bullet Bullet;

        public abstract Bullet[] Shoot(Transform shootPoint, Vector3 target);
    }
}