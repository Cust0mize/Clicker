using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class MainImageView : MonoBehaviour, IPointerDownHandler {
    private Tweener _tweener;
    private ScoreModel _scoreModel;

    [Inject]
    public void Construct(ScoreModel scoreModel) {
        _scoreModel = scoreModel;
    }

    private void Start() {
        transform.DORotate(new Vector3(0, 0, -5), 2).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerDown(PointerEventData eventData) {
        StartAnimation();
        _scoreModel.AddScoreToSingleClick();
    }

    public void StartAnimation() {
        if (_tweener == null) {
            _tweener = transform.DOScale(Vector3.one * 0.8f, 0.07f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
            {
                _tweener = null;
            }
            );
        }
        else {
            _tweener.Restart();
        }
    }
}
