using Gameplay.Card;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gameplay.GameLevel
{
    public class Level
    {
        #region Fields

        public Action OnCompleted;
        public CardData Target { get; private set; }
        public LevelData LevelInfo { get; private set; }
        public List<CardData> Items = new List<CardData>();
        #endregion

        public Level(LevelData data, ReadOnlyCollection<CardDataSet> cardDataSets, List<CardData> blockedCard)
        {
            LevelInfo = data;

            var cardSet = GenerateDataSet(cardDataSets);
            Target = GenerateTarget(cardSet, blockedCard);
            GenerateCardItems(cardSet);

            blockedCard.Add(Target);
        }

        public bool IsTarget(CardData cardData) => Target.Value.Equals(cardData.Value);

        public void Completed() => OnCompleted?.Invoke();

        private CardDataSet GenerateDataSet(ReadOnlyCollection<CardDataSet> cardDataSets)
        {
            var random = new Random();

            return cardDataSets[random.Next(cardDataSets.Count)];
        }

        private CardData GenerateTarget(CardDataSet cardSet, List<CardData> blockedTargets)
        {
            var random = new Random();
            var availableCard = cardSet.CardsData.Except(blockedTargets).ToList();

            return availableCard[random.Next(availableCard.Count)];
        }

        private void GenerateCardItems(CardDataSet cardDataSet)
        {
            int itemsCount = LevelInfo.RowCount * LevelInfo.ColumnCount;
            var indexItems = new Dictionary<int, CardData>();
            var random = new Random();

            var cardsData = cardDataSet.CardsData.Where(card => !card.Equals(Target)).ToList();
            cardsData = cardsData.OrderBy(_ => random.Next()).ToList();

            Items.AddRange(cardsData.Take(itemsCount - 1));
            Items.Add(Target);
            Items = Items.OrderBy(_ => random.Next()).ToList();
        }
    }
}
