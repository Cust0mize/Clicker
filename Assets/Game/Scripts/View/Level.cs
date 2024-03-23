using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "MySo/Level", order = 0)]
public class Level : ScriptableObject {
    [field: SerializeField] public Sprite SpriteImage { get; private set; }
    [field: SerializeField] public int Score { get; private set; }
    public int LevelIndex { get; private set; }

    public void SetLevelIndex(int levelIndex) {
        LevelIndex = levelIndex;
    }
}

public enum UpgradeType {
    AutoClick,
    SimpleClick
}