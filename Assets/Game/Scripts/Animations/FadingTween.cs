using DG.Tweening;
using UnityEngine;

namespace AnimationsDoTween
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadingTween : MonoBehaviour
    {
        [SerializeField]
        private float _durationFade;
        private CanvasGroup _canvasGroup;
        private Tween _tween;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeIn()
        {
            Fade(1f, _durationFade, () =>
            {
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
            });
        }

        public void FadeOut()
        {
            Fade(0f, _durationFade, () =>
            {
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
            });
        }

        private void Fade(float end, float duration, TweenCallback onEnd)
        {
            _tween?.Kill(false);

            _canvasGroup.alpha = end == 1f ? 0f : 1f;
            _tween = _canvasGroup.DOFade(end, duration);
            _tween.onComplete += onEnd;
        }
    }
}
