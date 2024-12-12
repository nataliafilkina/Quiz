using UnityEngine;
using UnityEngine.UI;
using System;
using AnimationsDoTween;

namespace UI
{
    public class UICardItem : MonoBehaviour
    {
        private BounceTween _bounceTween;
        private EaseInBounceTween _easeInBouceTween;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _bounceTween = GetComponent<BounceTween>();
            _easeInBouceTween = GetComponent<EaseInBounceTween>();
        }

        public void SetView(Sprite sprite)
        {
            _image.sprite = sprite;
            if (sprite.border.x != 0)
                _image.rectTransform.Rotate(0, 0, -90);
        }

        public void OnRightClick(Action OnComplete)
        {
            _bounceTween.Play(() => OnComplete.Invoke());
        }

        public void OnWrongClick()
        {
            _easeInBouceTween.Play();
        }
    }
}
