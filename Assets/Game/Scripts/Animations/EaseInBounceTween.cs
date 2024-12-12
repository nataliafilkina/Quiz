using DG.Tweening;
using UnityEngine;

namespace AnimationsDoTween
{
    public class EaseInBounceTween : MonoBehaviour
    {
        [SerializeField]
        private float _moveDistance = 5f;
        [SerializeField]
        private float _duration = 0.5f;

        private RectTransform _rect;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }

        public void Play()
        {
            Vector3 startPosition = _rect.anchoredPosition;

            _rect.DOAnchorPos(new Vector2(startPosition.x - _moveDistance, startPosition.y), _duration)
                   .SetEase(Ease.InBounce)
                   .OnComplete(() =>
                   {
                       _rect.DOAnchorPos(startPosition, _duration)
                            .SetEase(Ease.InBounce);
                   });
        }
    }
}