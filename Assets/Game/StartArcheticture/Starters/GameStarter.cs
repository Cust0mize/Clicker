using Assets.Game.StartArcheticture.UI;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Game.StartArcheticture.Starters {
    public class GameStarter : MonoBehaviour {
        private UIService _uIService;
        private List<IObserver> _observer;

        [Inject]
        private void Construct(
        UIService uIService,
        List<IObserver> observer
        ) {
            _uIService = uIService;
            _observer = observer;
        }

        private void Start() {
            //_uIService.Init();
            foreach (var item in _observer) {
                item.StartObserv();
            }
        }

        private void Update() {
        }
    }
}