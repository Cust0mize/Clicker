using UnityEngine.UI;
using UnityEngine;

public class LevelProgressBarView : MonoBehaviour, IObservable {
    [SerializeField] private Image _fillImage;

    public void UpdateBar(float value) {
        _fillImage.fillAmount = value;
    }
}
