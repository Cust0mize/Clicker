using Assets.Game.StartArcheticture.ClassExtension;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShopItemView : MonoBehaviour {
    [field: SerializeField] public RectTransform CurrentRect { get; private set; }

    [SerializeField] private TextMeshProUGUI _nameUI;
    [SerializeField] private TextMeshProUGUI _descriptionUI;
    [SerializeField] private TextMeshProUGUI _priceUI;
    [SerializeField] private Image _upIconImage;
    [SerializeField] private Image _downIconImage;
    [SerializeField] private Button _clickButton;

    public void Init() {

    }

    public void SetImage(ShopItems shopItems) {
        _nameUI.text = shopItems.Name;
        _descriptionUI.text = shopItems.GetDescription();
        _priceUI.text = shopItems.Price.ToString();
        _upIconImage.sprite = shopItems.UpIcon;
        _downIconImage.sprite = shopItems.DownIcon;
        _clickButton.RemoveAllAndSubscribeButton(Click);
    }

    private void Click() {
        
    }
}