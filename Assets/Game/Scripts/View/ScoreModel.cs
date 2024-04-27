using Assets.Game.StartArcheticture.Save_System;
using Cysharp.Threading.Tasks;
using System;
using R3;

public class LevelModel {
    public ReadOnlyReactiveProperty<float> LevelPrecentProperty => _levelPrecentProperty;
    private ReactiveProperty<float> _levelPrecentProperty = new();
    public ReadOnlyReactiveProperty<Level> CurrentLevelProperty => _currentLevelProperty;
    private ReactiveProperty<Level> _currentLevelProperty = new();
    public event Action LevelUpdate;

    private float _progressValue;

    private readonly GameData _gameData;
    private readonly Level[] _levels;

    private int _currentLevelIndex;

    public LevelModel(GameData gameData, Level[] levels) {
        _gameData = gameData;
        _levels = levels;

        for (int i = 0; i < _levels.Length; i++) {
            _levels[i].SetLevelIndex(i);
        }

        _currentLevelIndex = _gameData.CurrentLevelIndex;
        _currentLevelProperty.Value = _levels[_currentLevelIndex];
        AddProgressLevelValue((int)_gameData.LevelProgressValue);
    }

    public void AddProgressLevelValue(int value) {
        _levelPrecentProperty.Value = CalculatePrecent(value);
    }

    private float CalculatePrecent(int value) {
        _progressValue += Math.Abs(value);
        float resultPrecent = _progressValue / _currentLevelProperty.Value.Score;

        if (resultPrecent >= 1) {
            StartNextLevel();
            _progressValue = 0;
        }
        else {
        }

        _gameData.LevelProgressValue = _progressValue;
        return resultPrecent;
    }

    private void StartNextLevel() {
        _currentLevelIndex++;
        _gameData.CurrentLevelIndex = _currentLevelIndex;
        if (_levels.Length > _currentLevelIndex) {
            _currentLevelProperty.Value = _levels[_currentLevelIndex];
            LevelUpdate?.Invoke();
        }
    }
}

public class ScoreModel {
    public ReadOnlyReactiveProperty<int> ScoreValueProperty => _scoreValueProperty;
    private ReactiveProperty<int> _scoreValueProperty = new();
    public ReadOnlyReactiveProperty<int> AutoClickScoreProperty => _autoClickScoreProperty;
    private ReactiveProperty<int> _autoClickScoreProperty = new();

    private float _timeToClick = 1;
    private int _scoreToClick;
    private GameData _gameData;
    private readonly LevelModel _levelModel;

    public ScoreModel(GameData gameData, LevelModel levelModel) {
        _levelModel = levelModel;
        _gameData = gameData;
        _autoClickScoreProperty.Value = _gameData.AutoclickScore;
        _scoreValueProperty.Value = _gameData.AllScore;
        _scoreToClick = _gameData.ScoreToClick;

        AddScoreToAutoClick();
    }

    public void RemoveScore(int removeValue) {
        if (_scoreValueProperty.Value >= removeValue) {
            _scoreValueProperty.Value -= removeValue;
        }
    }

    public void AddScoreToSingleClick() {
        SetScore(_scoreToClick);
        _levelModel.AddProgressLevelValue(_scoreToClick);
    }

    public async void AddScoreToAutoClick() {
        while (true) {
            await UniTask.Delay(TimeSpan.FromSeconds(_timeToClick));
            SetScore(_autoClickScoreProperty.Value);
        }
    }

    public bool CanUpgrade(UpgradeInfo upgradeInfo) {
        bool result = false;
        if (CanBuy(upgradeInfo.UpgradePrice)) {
            RemoveScore(upgradeInfo.UpgradePrice);
            switch (upgradeInfo.UpgradeType) {
                case UpgradeType.AutoClick:
                    _autoClickScoreProperty.Value += upgradeInfo.UpgradeValue;
                    _gameData.AutoclickScore = _autoClickScoreProperty.Value;
                    break;
                case UpgradeType.SimpleClick:
                    _scoreToClick += upgradeInfo.UpgradeValue;
                    _gameData.ScoreToClick = _scoreToClick;
                    break;
            }
            result = true;
        }
        return result;
    }

    private bool CanBuy(int priceValue) {
        return _scoreValueProperty.Value >= priceValue;
    }

    private void SetScore(int value) {
        _scoreValueProperty.Value += Math.Abs(value);
        _gameData.AllScore = _scoreValueProperty.Value;
    }
}