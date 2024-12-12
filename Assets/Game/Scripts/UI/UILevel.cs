using AnimationsDoTween;
using Gameplay;
using Gameplay.Card;
using Gameplay.GameLevel;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UILevel : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _targetNameText;

        private Grid _grid;
        private Level _level;

        [Inject]
        private GameState _gameState;

        private void Awake()
        {
            _grid = GetComponentInChildren<Grid>();
        }

        private void Start()
        {
            _gameState.OnLevelChanged += OnRefresh;
            _gameState.OnStart += OnStartGame;

            OnStartGame();
        }

        public void OnClickCard(UICard uiCard, CardData cardData)
        {
            uiCard.AnimateClick(_level.IsTarget(cardData));
        }

        public void OnCompleted() => _level.Completed();

        private void OnStartGame()
        {
            _targetNameText.GetComponentInParent<FadingTween>().FadeIn();
            Refresh(_gameState.CurrentLevel, true);
        }

        private void OnRefresh(Level level)
        {
            Refresh(level, false);
        }

        private void Refresh(Level level, bool isStart)
        {
            _level = level;
            _targetNameText.text = level.Target.Value;
            _grid.Refresh(level.LevelInfo.ColumnCount, level.Items, isStart);
        }
    }
}
