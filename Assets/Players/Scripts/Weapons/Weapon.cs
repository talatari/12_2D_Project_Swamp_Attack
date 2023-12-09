using UnityEngine;

namespace Players
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private string _title;
        [SerializeField] private int _damage;
        [SerializeField] private int _speedShoot;
        [SerializeField] private int _price;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _isBuyed;
        [SerializeField] private Bullet _bullet;

        public abstract void Shoot(Transform shootPoint);
    }
}