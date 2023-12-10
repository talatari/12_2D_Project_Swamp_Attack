using UnityEngine;

namespace Players
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _startSpeed;

        private Vector2 _targetPosition;
        private float _elapsedTime;
        private Vector2 _startPosition;

        private void Start()
        {
            float liveTime = 30f;
            _startPosition = transform.position;
            Destroy(gameObject, liveTime);
        }

        private void Update()
        {
            if (_elapsedTime < _startSpeed)
            {
                float delta = _elapsedTime / _startSpeed;
                transform.position = Vector2.Lerp(_startPosition, _targetPosition, delta);
                _elapsedTime += Time.deltaTime;
            }
            else
            {
                transform.position = _targetPosition;
                Destroy(gameObject);
            }
        }

        public void SetTargetPosition(Vector2 targetPosition)
        {
            float minDistanceShoot = -3f;
            
            if (_startPosition.x + targetPosition.x < minDistanceShoot)
            {
                _targetPosition = targetPosition;
            }
            else
            {
                _targetPosition = targetPosition;
                _targetPosition.x = minDistanceShoot + targetPosition.x;
            }
        }
    }
}