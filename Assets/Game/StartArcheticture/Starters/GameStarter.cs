using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Zenject;

namespace Assets.Game.StartArcheticture.Starters {
    public class GameStarter : MonoBehaviour {
        [SerializeField] private MainImageView _mainImageView;
        [SerializeField] private AudioSource _mainSound;
        [SerializeField] private Canvas _uiCanvas;
        [SerializeField] private Image _back;
        private List<IObserver> _observer;

        [Inject]
        private void Construct(
        List<IObserver> observer
        ) {
            _observer = observer;
        }

        private void Start() {
            _back.gameObject.SetActive(StudentApi.IsInstanceBack);
            _uiCanvas.gameObject.SetActive(StudentApi.IsUIInstance);
            _mainImageView.gameObject.SetActive(StudentApi.IsSpawnCat);

            if (StudentApi.IsSoundPlay) {
                _mainSound.Play();
            }

            foreach (var item in _observer) {
                item.StartObserv();
            }
        }
    }
}