using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Game.StartArcheticture.Save_System {
    public class SaveSystem {
        private const string DATA_KEY = "SaveSystem";

        public void Save(GameData gameData) {
            string stringData = JsonConvert.SerializeObject(gameData);
            PlayerPrefs.SetString(DATA_KEY, stringData);
        }

        public GameData LoadFromDevice() {
            string stringData = PlayerPrefs.GetString(DATA_KEY);
            return JsonConvert.DeserializeObject<GameData>(stringData);
        }
    }
}