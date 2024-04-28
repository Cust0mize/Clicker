using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Game.StartArcheticture.Save_System {
    public class SaveSystem {
        private const string DATA_KEY = "SaveSystem";

        public void Save(GameData gameData) {
            if (StudentApi.IsEnableSaveSystem) {
                string stringData = JsonConvert.SerializeObject(gameData);
                PlayerPrefs.SetString(DATA_KEY, stringData);
            }
        }

        public GameData LoadFromDevice() {
            if (StudentApi.IsEnableSaveSystem) {
                string stringData = PlayerPrefs.GetString(DATA_KEY);
                return JsonConvert.DeserializeObject<GameData>(stringData);
            }
            else {
                return null;
            }
        }
    }
}