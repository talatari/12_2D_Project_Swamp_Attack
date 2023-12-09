using UnityEngine;

namespace Players
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _startSpeed;

        private void Start()
        {
            float liveTime = 5f;
            
            Destroy(gameObject, liveTime);
        }
        
        private void Update()
        {
            transform.Translate(Vector3.left * (_startSpeed * Time.deltaTime), Space.World);
        }
    }
}