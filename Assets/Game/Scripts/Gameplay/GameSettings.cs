using Gameplay.Card;
using Gameplay.GameLevel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Gameplay/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField]
        private List<LevelData> _levelsData = new List<LevelData>();

        public ReadOnlyCollection<LevelData> LevelData;

        [field: SerializeField]
        private List<CardDataSet> _cardDataSets = new List<CardDataSet>();

        public ReadOnlyCollection<CardDataSet> CardDataSets;

        protected void OnEnable()
        {
            LevelData = _levelsData.AsReadOnly();
            CardDataSets = _cardDataSets.AsReadOnly();
        }
    }
}
