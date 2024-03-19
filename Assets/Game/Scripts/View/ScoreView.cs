using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour, IObservable {
    [SerializeField] private TextMeshProUGUI _scoreValueUI;

    public void UpdateTextValue(int value) {
        _scoreValueUI.text = value.ToString();
    }
}
