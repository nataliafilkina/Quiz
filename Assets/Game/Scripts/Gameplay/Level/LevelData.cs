using UnityEngine;

namespace Gameplay.GameLevel
{
    [CreateAssetMenu(fileName = "Level", menuName = "Gameplay/Level")]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField]
        public int RowCount { get; private set; }

        [field: SerializeField]
        public int ColumnCount { get; private set; }

        private void OnValidate()
        {
            Mathf.Max(1, RowCount);
            Mathf.Max(1, ColumnCount);
        }
    }
}
