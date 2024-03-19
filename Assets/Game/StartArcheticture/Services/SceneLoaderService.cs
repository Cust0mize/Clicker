using UnityEngine.SceneManagement;

namespace Assets.Game.StartArcheticture.Services {
    public class SceneLoaderService {
        public void LoadScene(SceneName sceneName) {
            SceneManager.LoadScene(sceneName.ToString());
        }

        public void LoadAsyncScene(SceneName sceneName) {
            SceneManager.LoadSceneAsync(sceneName.ToString());
        }
    }

    public enum SceneName {
        EntryPoint,
        Game
    }
}