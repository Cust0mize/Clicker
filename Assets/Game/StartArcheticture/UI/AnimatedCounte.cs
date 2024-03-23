using Assets.Game.StartArcheticture.UI;
using DG.Tweening;
using UnityEngine;
using System;

namespace Cooking.Common.UI {
    public sealed class AnimatedCounte : MonoBehaviour {
        public int Value { get; private set; }
        public TextWrapper Text;

        public AnimationCurve Ease = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        private int _startCount;
        private int _endCount;
        private Action _callback;

        public Sequence Sequence { get; private set; }

        public bool IsPlaying => Sequence?.IsPlaying() ?? false;

        void OnDestroy() {
            Sequence = TweenHelper.ResetSequence(Sequence);
            _callback = null;
        }

        public void SetupStartCount(int value) {
            _startCount = value;
            SetupText(_startCount);
        }

        public void SetupEndCount(int value) {
            _endCount = value;
        }

        public void SetupEndAnimationCallback(Action callback) {
            _callback = callback;
        }

        public void StartAnimation(float duration = 0.8f, float timeScale = 1f) {
            Sequence = TweenHelper.ReplaceSequence(this, Sequence);
            Sequence.timeScale = timeScale;
            Sequence.Append(DOTween.To(x =>
            {
                SetupText(Mathf.RoundToInt(x));
            }, _startCount, _endCount, duration).SetEase(Ease));
            Sequence.AppendCallback(() =>
            {
                SetupText(_endCount);
            });
            Sequence.AppendCallback(InvokeCallback);
        }

        public void ForceCompleteAnimation() {
            if (Sequence == null) {
                return;
            }
            Sequence = TweenHelper.ReplaceSequence(this, Sequence, true, true);
        }

        private void InvokeCallback() {
            _callback?.Invoke();
            _callback = null;
        }

        public void SetupText(int value) {
            Value = value;
            if (Text) {
                Text.SetupText(Value);
            }
        }
    }
}