using Assets.Game.StartArcheticture.Configs;
using System;

namespace Assets.Game.StartArcheticture.Save_System {
    [Serializable]
    public class GameData {
        private SaveSystem _saveSystem;

        #region Properties
        private Locale _currentLocale;
        public Locale CurrentLocale {
            get { return _currentLocale; }
            set {
                _currentLocale = value;
                Save();
            }
        }

        private int _scoreToClick = 1;
        public int ScoreToClick {
            get => _scoreToClick;
            set {
                _scoreToClick = value;
                Save();
            }
        }

        #endregion

        public void Init(SaveSystem saveSystem) {
            _saveSystem = saveSystem;
        }

        public void Save() {
            if (_saveSystem != null) {
                _saveSystem.Save(this);
            }
        }

        public void SetValue(GameData gameData) {
            if (gameData == null) {
                return;
            }
            CurrentLocale = gameData.CurrentLocale;
            ScoreToClick = gameData.ScoreToClick;
        }

        public void ResetGame() {

        }
    }
}