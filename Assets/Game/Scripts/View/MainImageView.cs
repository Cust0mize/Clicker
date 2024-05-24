using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class MainImageView : MonoBehaviour, IPointerDownHandler, IObservable {
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private AudioSource _updateLevelSound;
    [SerializeField] private ParticleSystem _catParticle;
    [SerializeField] private FadeText _fadeText;
    private ScoreModel _scoreModel;
    private Tweener _tweener;

    [Inject]
    public void Construct(ScoreModel scoreModel) {
        _scoreModel = scoreModel;
    }

    private void Start() {
        if (StudentApi.IsRotateCat) {
            transform.DORotate(new Vector3(0, 0, -5), 2).SetLoops(-1, LoopType.Yoyo);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (Input.GetMouseButtonDown(0) && StudentApi.IsEnableClick) {
            StartAnimation();
            _scoreModel.AddScoreToSingleClick();

            if (StudentApi.IsSoundPlay) {
                _clickSound.PlayOneShot(_clickSound.clip);
            }

            if (StudentApi.IsPlayEffectClick) {
                var particle = Instantiate(_catParticle, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                FadeText fadeText = Instantiate(_fadeText);
                fadeText.Init(_scoreModel.ScoreToClick.ToString());
                Destroy(particle.gameObject, 1);
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

    public void SoundPlay() {
        _updateLevelSound.PlayOneShot(_updateLevelSound.clip);
    }
}

//Reva
//Reva
//Reva
//Reva
//Reva