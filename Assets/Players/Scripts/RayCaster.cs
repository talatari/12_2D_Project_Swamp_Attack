namespace Players
{
    using System;
    using UnityEngine;

    public class RayCaster : MonoBehaviour
    {
        private Camera _camera;

        public event Action<Vector3> HaveTarget;
    
        public Vector3 Target { get; private set; }

        private void Start() => 
            _camera = Camera.main;
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Interact();
        }

        private void Interact()
        {
            print("Interact");
            
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit))
            {
                Target = raycastHit.point;
                HaveTarget?.Invoke(Target);
                
                print(Target);
            }
        }
    }
}