using Enemies;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Player))]
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private Transform _shootPoint;
        
        private Player _player;

        private void Awake() => 
            _player = GetComponent<Player>();

        private void OnEnable() => 
            _player.PlayerGiveDamage += OnPlayerGiveDamage;

        private void OnDisable() => 
            _player.PlayerGiveDamage -= OnPlayerGiveDamage;

        private void OnPlayerGiveDamage(Enemy enemy)
        {
            if (enemy is not null)
                enemy.TakeDamage(_damage);
        }
    }
}