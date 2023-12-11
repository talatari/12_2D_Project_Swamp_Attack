using Enemies.StateMachine.States;
using Players;
using UnityEngine;

namespace Enemies.StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private State _startState;
        
        private Enemy _enemy;
        private State _currentState;
        private Player _player;
        
        public State CurrentState => _currentState;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _player = _enemy.Player;
            
            Reset(_startState);
        }

        private void Update()
        {
           if (_currentState is null)
               return;
           
           State nextState = _currentState.GetNextState();
           
           if (nextState is not null) 
               Transit(nextState);
        }

        private void Reset(State startState)
        {
            if (startState is not null)
            {
                _currentState = startState;
                _currentState.Enter(_player);
            }
        }

        private void Transit(State nextState)
        {
            if (_currentState is not null)
                _currentState?.Exit();
            
            _currentState = nextState;
            _currentState.Enter(_player);
        }
    }
}