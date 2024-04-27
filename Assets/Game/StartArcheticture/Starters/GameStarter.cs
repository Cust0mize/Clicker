using Assets.Game.StartArcheticture.UI;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Game.StartArcheticture.Starters {
    public class GameStarter : MonoBehaviour {
        private List<IObserver> _observer;

        [Inject]
        private void Construct(
        List<IObserver> observer
        ) {
            _observer = observer;
        }

        private void Awake() {
            
        }

        private void Start() {
            foreach (var item in _observer) {
                item.StartObserv();
            }
        }
    }
}