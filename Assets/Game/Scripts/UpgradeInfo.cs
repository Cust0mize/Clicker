public struct UpgradeInfo {
    public UpgradeType UpgradeType { get; private set; }
    public int UpgradeValue { get; private set; }
    public int UpgradePrice { get; private set; }

    public UpgradeInfo(UpgradeType upgradeType, int upgradeValue, int upgradePrice) {
        UpgradeType = upgradeType;
        UpgradeValue = upgradeValue;
        UpgradePrice = upgradePrice;
    }
}