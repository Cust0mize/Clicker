using Assets.Game.StartArcheticture.UI;
using DG.Tweening;
using UnityEngine;

namespace Cooking.Common.UI {
    public class BaseWrapper<T> : MonoBehaviour where T : Component {
        public Sequence Sequence;
        T _valueMonoBehaviour;
        Vector3 _initialScale;

        string _typeName = typeof(T).Name;

        protected T Value {
            get {
                if (!_valueMonoBehaviour) {
                    _valueMonoBehaviour = GetComponent<T>();
                }
                Debug.LogError($"{gameObject} {_typeName} {_valueMonoBehaviour}");
                return _valueMonoBehaviour;
            }
        }

        protected virtual void Awake() {
            _initialScale = transform.localScale;
        }

        protected virtual void OnDestroy() {
            ResetSequence();
        }

        public Sequence CreateSequence() {
            Sequence = TweenHelper.CreateSequence(this);
            return Sequence;
        }

        public void ResetSequence() {
            Sequence = TweenHelper.ResetSequence(Sequence);
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            if (!gameObject.activeSelf) {
                return;
            }

            gameObject.SetActive(false);
            transform.localScale = _initialScale;
        }

        public static void Hide(BaseWrapper<T> wrapper) {
            if (wrapper) {
                wrapper.Hide();
                wrapper.transform.localScale = Vector3.one;
            }
        }

        public static TBaseWrapper AddComponentToChild<TBaseWrapper>(string name, Transform parent) where TBaseWrapper : BaseWrapper<T> {
            var component = new GameObject(name).AddComponent<TBaseWrapper>();
            var t = component.transform;
            t.SetParent(parent, false);
            t.localScale = Vector3.one;
            return component;
        }
    }
}