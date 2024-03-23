using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class MainImageView : MonoBehaviour, IPointerDownHandler, IObservable {
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AudioSource _clickSound;
    private ScoreModel _scoreModel;
    private Tweener _tweener;

    [Inject]
    public void Construct(ScoreModel scoreModel) {
        _scoreModel = scoreModel;
    }

    private void Start() {
        if (StudentAPI.IsRotateAnimation) {
            transform.DORotate(new Vector3(0, 0, -5), 2).SetLoops(-1, LoopType.Yoyo);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (StudentAPI.IsClick) {
            if (Input.GetMouseButtonDown(0)) {
                StartAnimation();
                _scoreModel.AddScoreToSingleClick();
                _clickSound.PlayOneShot(_clickSound.clip);
            }
        }
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

    public void UpdateImage(Level level) {
        _spriteRenderer.sprite = level.SpriteImage;
    }
}

