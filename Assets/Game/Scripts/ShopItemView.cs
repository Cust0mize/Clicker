using Assets.Game.StartArcheticture.ClassExtension;
using UnityEngine.UI;
using UnityEngine;
using Zenject;
using TMPro;

public class ShopItemView : MonoBehaviour {
    [field: SerializeField] public RectTransform CurrentRect { get; private set; }

    [SerializeField] private TextMeshProUGUI _nameUI;
    [SerializeField] private AudioSource _buySource;
    [SerializeField] private TextMeshProUGUI _descriptionUI;
    [SerializeField] private TextMeshProUGUI _priceUI;
    [SerializeField] private Image _upIconImage;
    [SerializeField] private Image _downIconImage;
    [SerializeField] private Button _clickButton;
    private ScoreModel _scoreModel;
    private UpgradeInfo _upgradeInfo;

    [Inject]
    public void Init(ScoreModel scoreModel) {
        _scoreModel = scoreModel;
    }

    public void InitImage(ShopItems shopItems) {
        _nameUI.text = shopItems.Name;
        _descriptionUI.text = shopItems.GetDescription();
        _priceUI.text = shopItems.Price.ToString();
        _upIconImage.sprite = shopItems.UpIcon;
        _downIconImage.sprite = shopItems.DownIcon;
        _clickButton.RemoveAllAndSubscribeButton(Click);
        _upgradeInfo = new UpgradeInfo(shopItems.UpgradeType, shopItems.UpgradeValue, shopItems.Price);
    }

    public void ButtonChangeState(int currentScoreValue) {
        _clickButton.interactable = _upgradeInfo.UpgradePrice <= currentScoreValue;
    }

    private void Click() {
        if (_scoreModel.CanUpgrade(_upgradeInfo)) {
            _buySource.PlayOneShot(_buySource.clip);
        }
    }
}
