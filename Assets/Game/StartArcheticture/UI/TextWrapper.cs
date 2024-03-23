using UnityEngine;
using DG.Tweening.Core;
using System.Globalization;
using System.Text;
using TMPro;

namespace Cooking.Common.UI {
    [RequireComponent(typeof(TMP_Text))]
    public class TextWrapper : BaseWrapper<TMP_Text> {
        public TMP_Text Text => Value;

        public DOGetter<Color> DoGetterColor => () => Text.color;
        public DOSetter<Color> DoSetterColor => value => Text.color = value;

        public void SetupText(string text) {
            if (Text) {
                Text.text = text;
            }
        }

        public void SetupMaterial(Material material) {
            if (Text) {
                Text.fontMaterial = material;
            }
        }

        public void SetupColor(Color color) {
            if (Text) {
                Text.color = color;
            }
        }

        public void SetupText(string[] strings) {
            if (!Text) {
                return;
            }

            var builder = new StringBuilder();
            foreach (var s in strings) {
                builder.Append(s);
            }
            Text.text = builder.ToString();
        }

        public void SetupText(int number) {
            SetupText(number.ToString());
        }

        public void SetupText(float number) {
            SetupText(number.ToString(CultureInfo.InvariantCulture));
        }
    }
}