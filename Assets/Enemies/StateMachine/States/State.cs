using System.Collections.Generic;
using Enemies.StateMachine.Transiotions;
using Players;
using UnityEngine;

namespace Enemies.StateMachine.States
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private List<Transition> _transitions;
        
        protected Player Player { get; set; }

        public void Enter(Player player)
        {
            if (enabled == false)
            {
                Player = player;
                enabled = true;

                foreach (Transition transition in _transitions)
                {
                    transition.enabled = true;
                    transition.Init(Player);
                }
            }
        }

        public void Exit()
        {
            if (enabled)
                foreach (Transition transition in _transitions)
                    transition.enabled = false;
        }

        public State GetNextState()
        {
            foreach (Transition transition in _transitions)
                if (transition.NeedTransit)
                    return transition.NextState;

            return null;
        }
    }
}