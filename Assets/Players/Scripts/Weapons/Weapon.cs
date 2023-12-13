using System;
using UnityEngine;

namespace Players
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private string _title;
        [SerializeField] protected int Damage;
        [SerializeField] protected float ShootDelay;
        [SerializeField] private int _price;
        [SerializeField] private bool _isBuyed;
        [SerializeField] private Sprite _sprite;
        [SerializeField] protected Bullet Bullet;
        
        public abstract event Action UsedWeapon;
        
        public string Title => _title;
        public int Price => _price;
        public bool IsBuyed => _isBuyed;
        public Sprite Sprite => _sprite;

        public abstract void UseWeapon(Transform shootPoint, Vector3 target);

        public abstract void UseWeapon();

        public void Buy() => 
            _isBuyed = true;
    }
}