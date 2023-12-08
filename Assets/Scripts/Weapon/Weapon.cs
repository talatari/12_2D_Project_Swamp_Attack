﻿using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] private Sprite _icon;
    [SerializeField] protected Bullet Bullet;

    public string Label => _label;
    public int Price => _price;
    public bool IsBuyed => _isBuyed;
    public Sprite Icon => _icon;

    public abstract void Shoot(Transform shootPoint);

    public void Buy() => 
        _isBuyed = true;
}