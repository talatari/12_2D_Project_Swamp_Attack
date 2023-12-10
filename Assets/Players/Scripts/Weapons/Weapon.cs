using UnityEngine;

namespace Players
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private string _title;
        [SerializeField] protected int Damage;
        [SerializeField] protected float SpeedShoot;
        [SerializeField] private int _price;
        [SerializeField] private bool _isBuyed;
        [SerializeField] private Sprite _icon;
        [SerializeField] protected Bullet Bullet;

        public abstract void Shoot(Transform shootPoint, Vector3 target);
    }
}