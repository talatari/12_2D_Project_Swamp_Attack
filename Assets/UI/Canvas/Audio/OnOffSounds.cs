using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OnOffSounds : MonoBehaviour
    {
        [SerializeField] private GameObject _sounds;
        [SerializeField] private RawImage _soundsRawImage;

        private Texture2D _onSoundsTexture;
        private Texture2D _offSoundsTexture;
        
        public event Action SwithSounds;
        
        private void Start()
        {
            _onSoundsTexture = Resources.Load<Texture2D>("SoundsOn");
            _offSoundsTexture = Resources.Load<Texture2D>("SoundsOff");
        }

        public void OnOff()
        {
            _sounds.SetActive(!_sounds.activeSelf);
            _soundsRawImage.texture = _sounds.activeSelf ? _onSoundsTexture : _offSoundsTexture;
            
            SwithSounds?.Invoke();
        }
    }
}