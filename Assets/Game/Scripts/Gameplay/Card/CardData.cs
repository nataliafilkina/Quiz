using System;
using UnityEngine;

namespace Gameplay.Card
{
    [Serializable]
    public struct CardData
    {
        [field: SerializeField]
        public string Value { get; private set; }

        [field: SerializeField]
        public Sprite Sprite { get; private set; }
    }
}
