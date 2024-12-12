using DG.Tweening;
using System;
using UnityEngine;

namespace AnimationsDoTween
{
    public class BounceTween : MonoBehaviour
    {
        [SerializeField]
        private float _scaleFactor = 1.5f;

        [SerializeField]
        private float _duration = 0.5f;

        private RectTransform _rect;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }

        public void Play(Action OnComplete)
        {
            Vector3 startScale = _rect.localScale;
            Sequence sequence = DOTween.Sequence();

            sequence.Append(_rect.DOScale(startScale * _scaleFactor, _duration).SetEase(Ease.OutQuad))
                    .Append(_rect.DOScale(startScale, _duration * 0.5f).SetEase(Ease.InOutQuad))
                    .AppendInterval(0.5f)
                    .OnComplete(() => OnComplete?.Invoke());
        }
    }
}
