using Gameplay.Card;
using Gameplay.GameLevel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gameplay
{
    public class GameState
    {
        public Action OnStart;
        public Action<Level> OnLevelChanged;
        public Action OnGameOver;

        private ReadOnlyCollection<LevelData> _levelData;
        private ReadOnlyCollection<CardDataSet> _cardDataSets;

        private List<CardData> _blockedTargets = new List<CardData>();

        private int _currentLevelIndex;
        public Level CurrentLevel { get; private set; }

        public GameState(GameSettings data)
        {
            _levelData = data.LevelData;
            _cardDataSets = data.CardDataSets;

            Reset();
        }

        public void SetNextLevel()
        {
            CurrentLevel.OnCompleted -= SetNextLevel;

            if (_currentLevelIndex == _levelData.Count - 1)
            {
                OnGameOver.Invoke();
                return;
            }

            _currentLevelIndex++;
            CreateLevel();
            OnLevelChanged?.Invoke(CurrentLevel);
        }

        public void Reset()
        {
            _currentLevelIndex = 0;
            _blockedTargets.Clear();

            CreateLevel();
            OnStart?.Invoke();
        }

        private void CreateLevel()
        {
            CurrentLevel = new Level(_levelData[_currentLevelIndex], _cardDataSets, _blockedTargets);
            CurrentLevel.OnCompleted += SetNextLevel;
        }
    }
}
