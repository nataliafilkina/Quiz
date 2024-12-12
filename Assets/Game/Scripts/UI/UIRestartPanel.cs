using AnimationsDoTween;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UIRestartPanel : MonoBehaviour
    {
        private FadingTween _fadePanel;
        private Button _restartBtn;

        [Inject]
        private GameState _gameState;

        private void Awake()
        {
            _fadePanel = GetComponentInChildren<FadingTween>();
            _restartBtn = GetComponentInChildren<Button>();
            _gameState.OnGameOver += ActivePanel;

            _restartBtn.gameObject.SetActive(false);
        }

        private void ActivePanel()
        {
            _restartBtn.gameObject.SetActive(true);
            _fadePanel.FadeIn();
            _restartBtn.onClick.AddListener(OnRestartClick);
        }

        private void OnRestartClick()
        {
            _restartBtn.gameObject.SetActive(false);
            _fadePanel.FadeOut();
            _restartBtn.onClick.RemoveListener(OnRestartClick);
            _gameState.Reset();
        }
    }
}
