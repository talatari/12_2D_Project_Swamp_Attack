namespace Players
{
    using System;
    using UnityEngine;

    public class RayCaster : MonoBehaviour
    {
        private Camera _camera;

        public event Action<Vector2> HaveTarget;
    
        public Vector2 Target { get; private set; }

        private void Start() => 
            _camera = Camera.main;
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Interact();
        }

        private void Interact()
        {
            Target = _camera.ScreenToWorldPoint(Input.mousePosition);
            HaveTarget?.Invoke(Target);
        }
    }
}