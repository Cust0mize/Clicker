using Assets.Game.StartArcheticture.Save_System;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine;
using R3;
using Zenject;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainImageView : MonoBehaviour, IPointerDownHandler {
    private Tweener _tweener;
    private ScoreModel _scoreModel;

    [Inject]
    public void Construct(ScoreModel scoreModel) {
        _scoreModel = scoreModel;
    }

    private void Start() {
        transform.DORotate(new Vector3(0, 0, -5), 2).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerDown(PointerEventData eventData) {
        StartAnimation();
        _scoreModel.AddScoreToClick();
    }

    public void StartAnimation() {
        if (_tweener == null) {
            _tweener = transform.DOScale(Vector3.one * 0.8f, 0.07f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
            {
                _tweener = null;
            }
            );
        }
        else {
            _tweener.Restart();
        }
    }
}

public class ScoreModel {
    public ReadOnlyReactiveProperty<int> ScoreValueProperty => _scoreValueProperty;
    private ReactiveProperty<int> _scoreValueProperty = new();
    private int _autoClickScore = 1;
    private int _scoreToClick;
    private float _timeToClick = 1;

    public ScoreModel(GameData gameData) {
        _scoreToClick = gameData.ScoreToClick;
        AddAutoScore();
    }

    private void AddScore(int value) {
        _scoreValueProperty.Value += value;
    }

    public void AddScoreToClick() {
        AddScore(_scoreToClick);
    }

    public async void AddAutoScore() {
        while (true) {
            await UniTask.Delay(TimeSpan.FromSeconds(_timeToClick));
            AddScore(_autoClickScore);
        }
    }
}