using System;
using UnityEngine;

namespace Player.Scripts
{
    public class Player : MonoBehaviour
    {
        private Health _health;

        private void Start()
        {
            _health = GetComponent<Health>();
        }
    }
}