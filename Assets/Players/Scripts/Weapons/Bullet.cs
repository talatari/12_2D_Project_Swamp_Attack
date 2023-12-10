using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _shootDelay;

        private float _liveTime = 3f;
        private float _elapsedTime;
        private Vector3 _startPosition;
        private Vector3 _targetPosition;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            _startPosition = transform.position;
            Destroy(gameObject, _liveTime);
        }

        private void Update()
        {
            _rigidbody2D.MovePosition(_targetPosition);

            // if (_elapsedTime < _shootDelay)
            // {
            //     float delta = _elapsedTime / _shootDelay;
            //     transform.position = Vector3.Lerp(_startPosition, _targetPosition, delta);
            //     _elapsedTime += Time.deltaTime;
            // }
            // else
            // {
            //     transform.position = _targetPosition;
            //     Destroy(gameObject);
            // }
        }

        public void SetTargetPosition(Vector3 targetPosition) => 
            _targetPosition = targetPosition;
    }
}