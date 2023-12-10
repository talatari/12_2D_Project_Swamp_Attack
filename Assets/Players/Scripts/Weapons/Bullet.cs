using UnityEngine;

namespace Players
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _startSpeed;

        private Vector3 _targetPosition;

        private void Start()
        {
            float liveTime = 3f;
            
            Destroy(gameObject, liveTime);
        }
        
        private void Update()
        {
            // transform.Translate(Vector3.left * (_startSpeed * Time.deltaTime), Space.World);
            
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _startSpeed * Time.deltaTime);
        }

        public void SetTargetPosition(Vector3 targetPosition) => 
            _targetPosition = targetPosition;
    }
}