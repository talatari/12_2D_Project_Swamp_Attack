using UnityEngine;

namespace Enemies
{
    public class CloseDistance : Transition
    {
        [SerializeField] private float _transitionRange;
        [SerializeField] private float _rangeSpread;

        private void Start() => 
            _transitionRange += Random.Range(-1 * _rangeSpread, _rangeSpread);

        private void Update()
        {
            if (Player == null)
                return;
            
            if (Vector2.Distance(transform.position, Player.transform.position) < _transitionRange) 
                NeedTransit = true;
        }
        
        public void Transit() => 
            NeedTransit = true;
    }
}