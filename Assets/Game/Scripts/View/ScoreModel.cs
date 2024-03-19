using Assets.Game.StartArcheticture.Save_System;
using Cysharp.Threading.Tasks;
using System;
using R3;

public class ScoreModel {
    public ReadOnlyReactiveProperty<int> ScoreValueProperty => _scoreValueProperty;
    private ReactiveProperty<int> _scoreValueProperty = new();
    public ReadOnlyReactiveProperty<int> AutoClickScoreProperty => _autoClickScoreProperty;
    private ReactiveProperty<int> _autoClickScoreProperty = new();

    private float _timeToClick = 1;
    private int _scoreToClick;

    public ScoreModel(GameData gameData) {
        _autoClickScoreProperty.Value = gameData.AutoclickScore;
        _scoreValueProperty.Value = gameData.AllScore;
        _scoreToClick = gameData.ScoreToClick;
        AddScoreToAutoClick();
    }

    public void RemoveScore(int removeValue) {
        if (_scoreValueProperty.Value >= removeValue) {
            _scoreValueProperty.Value -= removeValue;
        }
    }

    public void AddScoreToSingleClick() {
        SetScore(_scoreToClick);
    }

    public async void AddScoreToAutoClick() {
        while (true) {
            await UniTask.Delay(TimeSpan.FromSeconds(_timeToClick));
            SetScore(_autoClickScoreProperty.Value);
        }
    }

    private void SetScore(int value) {
        _scoreValueProperty.Value += Math.Abs(value);
    }
}
