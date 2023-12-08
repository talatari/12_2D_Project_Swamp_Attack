using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState is null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState is not null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState is not null)
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currentState is not null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState is not null)
            _currentState.Enter(_target);
    }
}