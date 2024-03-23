using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Assets.Game.StartArcheticture.ClassExtension;
using Zenject;

public class ShopViewController : MonoBehaviour {
    [SerializeField] private VerticalLayoutGroup _horizontalLayoutGroup;
    [SerializeField] private ShopItems[] _shopItemsView;
    [SerializeField] private RectTransform _targetRext;

    [SerializeField] private ShopItemView _shopItemViewPrefab;

    private List<ShopItemView> _shopItemViews = new();
    private DiContainer _diContainer;

    [Inject]
    private void Init(DiContainer diContainer) {
        _diContainer = diContainer;
    }

    private void Start() {
        if (StudentAPI.ShopInstance && _shopItemsView.NotEmpty()) {
            foreach (var item in _shopItemsView) {
                ShopItemView element = _diContainer.InstantiatePrefabForComponent<ShopItemView>(_shopItemViewPrefab, _targetRext);
                element.InitImage(item);
                _shopItemViews.Add(element);
            }

            RectUtils.SetVerticalRectInLayoutGroup(_targetRext, _horizontalLayoutGroup, _shopItemViews[0].CurrentRect.rect.height, _shopItemViews.Count);
        }
    }
}