using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour, IObservable {
    //[SerializeField] private AnimatedCounte _animatedCounter;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    public void UpdateTextValue(int value) {
        //_animatedCounter.SetupStartCount(_animatedCounter.Value);
        //_animatedCounter.SetupEndCount(_animatedCounter.Value + value);
        //_animatedCounter.StartAnimation();
        _textMeshProUGUI.text = value.ToString();
        //_animatedCounter.SetupText(value);
    }
}