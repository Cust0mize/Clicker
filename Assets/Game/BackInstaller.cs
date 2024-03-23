using UnityEngine.UI;
using UnityEngine;

public class BackInstaller : MonoBehaviour {
    [SerializeField] private Sprite _spriteBack;
    [SerializeField] private Image _image;

    void Start() {
        if (StudentAPI.IsBackInstance) {
            _image.color = Color.white;
            _image.sprite = _spriteBack;
        }
    }
}
