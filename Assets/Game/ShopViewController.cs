using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopViewController : MonoBehaviour {
    [SerializeField] private VerticalLayoutGroup _horizontalLayoutGroup;
    [SerializeField] private ShopItems[] _shopItemsView;
    [SerializeField] private RectTransform _targetRext;

    [SerializeField] private ShopItemView _shopItemViewPrefab;

    private List<ShopItemView> _shopItemViews = new();

    private void Start() {
        foreach (var item in _shopItemsView) {
            ShopItemView element = Instantiate(_shopItemViewPrefab, _targetRext);
            element.SetImage(item);
            _shopItemViews.Add(element);
        }

        RectUtils.SetVerticalRectInLayoutGroup(_targetRext, _horizontalLayoutGroup, _shopItemViews[0].CurrentRect.rect.height, _shopItemViews.Count);
    }
}
