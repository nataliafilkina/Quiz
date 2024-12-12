using AnimationsDoTween;
using Gameplay.Card;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UI
{
    public class UICard : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private GameObject _starsPrefab;

        private UICardItem _UIItem;
        private CardData _cardData;
        private Transform _parent;
        private UILevel _UILevel;
        private BounceTween _bounceTween;

        [Inject]
        public void Construct(CardData cardData, Transform parent)
        {
            _cardData = cardData;
            _parent = parent;
        }

        public class Factory : PlaceholderFactory<CardData, Transform, UICard>
        {
        }

        private void Awake()
        {
            _UIItem = GetComponentInChildren<UICardItem>();
            transform.SetParent(_parent, false);

            _UILevel = GetComponentInParent<UILevel>();
            _bounceTween = GetComponent<BounceTween>();
        }

        private void Start()
        {
            _UIItem.SetView(_cardData.Sprite);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _UILevel.OnClickCard(this, _cardData);
        }

        public void AnimateClick(bool isTarget)
        {
            if (isTarget)
            {
                var particlePosition = transform.position;
                particlePosition.z -= 10;
                var particle = Instantiate(_starsPrefab, particlePosition, transform.rotation, transform.parent);

                _UIItem.OnRightClick(() => _UILevel.OnCompleted());
            }
            else
            {
                _UIItem.OnWrongClick();
            }
        }

        public void AnimateCreate(Action complete)
        {
            _bounceTween.Play(() => complete.Invoke());
        }

        public IEnumerator AnimateCreateCoroutine()
        {
            bool isComplete = false;
            _bounceTween.Play(() => isComplete = true);
            yield return new WaitUntil(() => isComplete);
        }
    }
}
