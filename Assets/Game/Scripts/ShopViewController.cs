using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Zenject;
using R3;

public class ShopViewController : MonoBehaviour {
    [SerializeField] private VerticalLayoutGroup _horizontalLayoutGroup;
    [SerializeField] private RectTransform _targetRext;

    [SerializeField] private ShopItemView _shopItemViewPrefab;

    private List<ShopItemView> _shopItemViews = new();
    private DiContainer _diContainer;
    private ShopItems[] _shopItems;

    [Inject]
    private void Init(DiContainer diContainer, ShopItems[] shopItems) {
        _diContainer = diContainer;
        _shopItems = shopItems;
    }

    private void Start() {
        foreach (var item in _shopItems) {
            ShopItemView element = _diContainer.InstantiatePrefabForComponent<ShopItemView>(_shopItemViewPrefab, _targetRext);
            element.InitImage(item);
            ShopItemViewObserver shopItemViewObserver = new(element, _diContainer.Resolve<ScoreModel>());
            _shopItemViews.Add(element);
        }

        RectUtils.SetVerticalRectInLayoutGroup(_targetRext, _horizontalLayoutGroup, _shopItemViews[0].CurrentRect.rect.height, _shopItemViews.Count);
    }
}

public class ShopItemViewObserver {
    public ShopItemViewObserver(ShopItemView shopItemView, ScoreModel scoreModel) {
        scoreModel.ScoreValueProperty.Subscribe(shopItemView.ButtonChangeState);
    }
}