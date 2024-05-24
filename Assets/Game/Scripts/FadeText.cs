using UnityEngine;
using DG.Tweening;
using TMPro;

public class FadeText : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _textUI;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Init(string fadeText) {
        _canvas.worldCamera = Camera.main;
        _canvas.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        _textUI.transform.DOMoveY(transform.position.y + 10, 2);
        _canvasGroup.DOFade(0, 2);
        _textUI.text = fadeText;


        //Deveower
    }
}
