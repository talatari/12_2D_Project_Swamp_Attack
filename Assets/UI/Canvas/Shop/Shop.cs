using UnityEngine;

namespace UI
{
    public class Shop : MonoBehaviour
    {
        private void OnEnable() => 
            Time.timeScale = 0;

        private void OnDisable() => 
            Time.timeScale = 1;
    }
}