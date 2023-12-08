using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delayAttack;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start() => 
        _animator = GetComponent<Animator>();

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delayAttack;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play(StatesAnimatorData.Params.Attack);
        target.ApplyDamage(_damage);
    }
}