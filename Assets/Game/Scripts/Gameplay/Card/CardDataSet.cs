using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Gameplay.Card
{
    [CreateAssetMenu(fileName = "CardDataSet", menuName = "Gameplay/Card/CardDataSet")]
    public class CardDataSet : ScriptableObject
    {
        [field: SerializeField]
        private List<CardData> _cardsData = new List<CardData>();

        public ReadOnlyCollection<CardData> CardsData;

        protected void OnEnable()
        {
            CardsData = _cardsData.AsReadOnly();
        }
    }
}
