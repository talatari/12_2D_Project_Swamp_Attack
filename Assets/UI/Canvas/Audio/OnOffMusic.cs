using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OnOffMusic : MonoBehaviour
    {
        [SerializeField] private GameObject _music;
        [SerializeField] private RawImage _musicRawImage;

        private Texture2D _onMusicTexture;
        private Texture2D _offMusicTexture;
        
        private void Start()
        {
            _onMusicTexture = Resources.Load<Texture2D>("MusicOn");
            _offMusicTexture = Resources.Load<Texture2D>("MusicOff");
        }

        public void OnOff()
        {
            if (_music != null)
            {
                _music.SetActive(!_music.activeSelf);
                _musicRawImage.texture = _music.activeSelf ? _onMusicTexture : _offMusicTexture;
            }
        }
    }
}