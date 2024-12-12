using Gameplay.Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class Grid : MonoBehaviour
    {
        private GridLayoutGroup _gridGroup;

        [Inject]
        private UICard.Factory _cardFactory;

        private void Awake()
        {
            _gridGroup = GetComponent<GridLayoutGroup>();
        }

        public void Refresh(int columnCount, List<CardData> items, bool isAnimated)
        {
            Clear();
            _gridGroup.constraintCount = columnCount;

            if (isAnimated)
            {
                StartCoroutine(CreateInTurns(items));
                return;
            }

            foreach (CardData item in items)
            {
                _cardFactory.Create(item, _gridGroup.transform);
            }

        }

        public void Clear()
        {
            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
        }

        private IEnumerator CreateInTurns(List<CardData> items)
        {
            foreach (CardData item in items)
            {
                var card = _cardFactory.Create(item, _gridGroup.transform);

                yield return WaitAnimationCard(card);
            }
        }

        private IEnumerator WaitAnimationCard(UICard card)
        {
            bool isComplete = false;
            card.AnimateCreate(() => isComplete = true);
            yield return new WaitUntil(() => isComplete);
        }
    }
}
