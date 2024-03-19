using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Game.StartArcheticture.ClassExtension {
    public static class Extension {
        public static void RemoveAllAndSubscribeButton(this Button button, UnityAction unityAction) {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(unityAction);
        }
    }

    public static class DictionaryExtensions {
        public static void Dictionarewr<T1, T2>(this Dictionary<T1, T2> keyValuePairs, T1 key, T2 value) {
            if (!keyValuePairs.TryAdd(key, value)) {
                keyValuePairs.Add(key, value);
            }
        }
    }

    public static class ListExtensions {
        public static T GetRandomItem<T>(this IList<T> list) {
            return list[Random.Range(0, list.Count)];
        }

        public static void Shuffle<T>(this IList<T> list) {
            for (var i = list.Count - 1; i > 1; i--) {
                var j = Random.Range(0, i + 1);
                var value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
        }

        public static SearchType FindFirstOfType<InterfaceType, SearchType>(this List<InterfaceType> values) where SearchType : InterfaceType {
            SearchType result = default;

            for (int index = 0; index < values.Count; index++) {
                if (values[index] is SearchType resultItem) {
                    result = resultItem;
                    break;
                }
            }

            return result;
            //Дублирует функционал:
            //values.OfType<ScoreModel>().FirstOrDefault();
        }
    }

    public static class TransformExtensions {
        public static void DestroyChildren(this Transform transform) {
            for (var i = transform.childCount - 1; i >= 0; i--)
                Object.Destroy(transform.GetChild(i).gameObject);
        }

        public static void ResetTransformation(this Transform transform) {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
    }

    public static class Vector3Extensions {
        public static Vector3 WithX(this Vector3 value, float x) {
            value.x = x;
            return value;
        }

        public static Vector3 WithY(this Vector3 value, float y) {
            value.y = y;
            return value;
        }

        public static Vector3 WithZ(this Vector3 value, float z) {
            value.z = z;
            return value;
        }

        public static Vector3 AddX(this Vector3 value, float x) {
            value.x += x;
            return value;
        }

        public static Vector3 AddY(this Vector3 value, float y) {
            value.y += y;
            return value;
        }

        public static Vector3 AddZ(this Vector3 value, float z) {
            value.z += z;
            return value;
        }
    }
}