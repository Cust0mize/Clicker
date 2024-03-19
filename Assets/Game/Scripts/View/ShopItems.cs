using UnityEngine;

[CreateAssetMenu(fileName = "ShopItems", menuName = "MySo/ShopItems", order = 0)]
public class ShopItems : ScriptableObject {
    [field: SerializeField] public UpgradeType UpgradeType { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public Sprite UpIcon { get; private set; }
    [field: SerializeField] public Sprite DownIcon { get; private set; }
    [field: SerializeField] public int UpgradeValue { get; private set; }
    [field: SerializeField] private string Description;

    public string GetDescription() {
        return $"+{UpgradeValue} {Description}";
    }
}
