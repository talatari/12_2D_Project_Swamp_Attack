using System.Collections;
using Enemies;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EnemyWaveBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _waveEnemyCountText;
        [SerializeField] private TextMeshProUGUI _waveNumberText;
        [SerializeField] private Image _fillBar;
        [SerializeField] private Gradient _gradient;

        private Spawner _spawner;
        private Coroutine _coroutineFadeEffectAlphaText;
        private string _waveText = "Wave ";
        private string _bossText = "BOSS";
        private float _duration = 2f;

        private void Awake()
        {
            _spawner = FindObjectOfType<Spawner>();
            _spawner.WaveStarted += OnShowWaveNumber;
            _spawner.WaveChanged += OnRefreshHealthBar;
        }

        private void OnDestroy()
        {
            _spawner.WaveStarted -= OnShowWaveNumber;
            _spawner.WaveChanged -= OnRefreshHealthBar;
        }

        private void OnShowWaveNumber(int waveNumber)
        {
            if (waveNumber > 0)
                StartFadeText(_waveText + waveNumber);
            else
                StartFadeText(_bossText);
        }

        private void StartFadeText(string text)
        {
            if (_coroutineFadeEffectAlphaText != null)
                StopCoroutine(_coroutineFadeEffectAlphaText);

            _waveNumberText.text = text;

            _coroutineFadeEffectAlphaText = StartCoroutine(FadeEffectAlphaText());
        }

        private void OnRefreshHealthBar(int spawnedEnemy, int maxSpawnEnemy)
        {
            _waveEnemyCountText.text = spawnedEnemy + " / " + maxSpawnEnemy;
            _fillBar.fillAmount = (float) spawnedEnemy / maxSpawnEnemy;
            _fillBar.color = _gradient.Evaluate(_fillBar.fillAmount);
        }

        private IEnumerator FadeEffectAlphaText()
        {
            float minAlpha = 0;
            float maxAlpha = 1000;
            float elapsedTime = 0;
            int toFontSize = 100;
            int fromFontSize = 140;
            
            Color color = _waveNumberText.color;

            while (elapsedTime < _duration)
            {
                color.a = Mathf.Lerp(maxAlpha, minAlpha, elapsedTime / _duration) / maxAlpha;
                _waveNumberText.color = color;
                
                _waveNumberText.fontSize = Mathf.Lerp(fromFontSize, toFontSize, elapsedTime / _duration);
                
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            color.a = minAlpha;
            _waveNumberText.color = color;
        }
    }
}