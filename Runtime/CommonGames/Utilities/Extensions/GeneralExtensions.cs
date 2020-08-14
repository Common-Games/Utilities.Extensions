using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CommonGames.Utilities.Extensions
{
    //using SRandom = System.Random;

    public static partial class GeneralExtensions
    {
        /// <summary> Swaps values <paramref name="left"/> and <paramref name="right"/> </summary>
        [PublicAPI]
        public static void Swap<T>(ref T left, ref T right)
        {
            T __temp = right;
            
            right = left;
            left = __temp;
        }
        
        public static void For(this int i, in Action<int> action)
        {
            for(int __j = 0; __j < i; __j++)
            {
                action(obj: __j);
            }
        }

        /*
        /// <summary>
        /// Returns random value in range
        /// </summary>
        public static float RandomRange(float min, float max, SRandom random = null)
        {
            SRandom __usedRandom = random ?? RANDOM;
            float __lerp = (float)__usedRandom.NextDouble();
            return Mathf.Lerp(a: min, b: max, t: __lerp);
        }

        public static Vector3 RandomVector3(float min, float max, SRandom random = null)
        {
            SRandom __usedRandom = random ?? RANDOM;
            return new Vector3(
                x: RandomRange(min: min, max: max, random: random), 
                y: RandomRange(min: min, max: max, random: random), 
                z: RandomRange(min: min, max: max, random: random));
        }

        public static Vector3Int RandomVector3Int(float min, float max, SRandom random = null)
        {
            Vector3 __vector = RandomVector3(min: min, max: max, random: random);
            return new Vector3Int(
                x: Mathf.RoundToInt(f: __vector.x), 
                y: Mathf.RoundToInt(f: __vector.y), 
                z: Mathf.RoundToInt(f: __vector.z));
        }
        */

        /// <summary>Converts class to type T, instead of having to do (MyClass as T). </summary>
        [PublicAPI]
        public static T Convert<T>(this object obj) where T : class => obj as T;

        /// <summary>
        /// Shortcut for Unity's SetActive.
        /// </summary>
        public static void SetActive(this MonoBehaviour behaviour, bool enabled = true)
            => behaviour.gameObject.SetActive(value: enabled);

        /// <summary>
        /// Converts float into a string that visualizes the time digitally.
        /// </summary>
        public static string ToTimeString(this float seconds)
        {
            TimeSpan __result = TimeSpan.FromSeconds(value: seconds);
            return string.Format(format: $"{__result.Hours}:{__result.Minutes}:{__result.Seconds}");
        }
        
        #region GetIfNull
        
        [PublicAPI]
        public static T GetIfNull<T>(this T obj, in Func<T> getMethod) where T : Component
            => obj ? obj : getMethod?.Invoke();
        
        #region GameObject Context
        
        [PublicAPI]
        public static T GetIfNull<T>(this T obj, in GameObject context) where T : Component
            => obj ? obj : context.GetComponent<T>();
        
        [PublicAPI]
        public static T GetInChildrenIfNull<T>(this T obj, in GameObject context) where T : Component
            => obj ? obj : context.GetComponentInChildren<T>();
        
        [PublicAPI]
        public static T TryGetIfNull<T>(this T obj, in GameObject context) where T : Component
        {
            if(obj != null) return obj;

            context.TryGetComponent(component: out T __returnedObject);
            return __returnedObject;
        }

        [PublicAPI]
        public static T TryGetInChildrenIfNull<T>(this T obj, in GameObject context) where T : Component
            => context.TryGetComponent(component: out T __returnedObject) ? __returnedObject : context.GetComponentInChildren<T>();
        
        [PublicAPI]
        public static T TryGetInParentIfNull<T>(this T obj, in GameObject context) where T : Component
            => context.TryGetComponent(component: out T __returnedObject) ? __returnedObject : context.GetComponentInParent<T>();
        
        [PublicAPI]
        public static T TryGetInParentOrChildrenIfNull<T>(this T obj, in GameObject context) where T : Component
        {
            if(context.TryGetComponent(component: out T __triedComponent)) return __triedComponent;

            T __componentInParent = context.GetComponentInParent<T>();
            
            return __componentInParent ? __componentInParent : context.GetComponentInParent<T>();
        }

        #endregion

        #region Component Context

        [PublicAPI]
        public static T GetIfNull<T>(this T obj, in Component context) where T : Component
            => GetIfNull(obj: obj, context: context.gameObject);

        [PublicAPI]
        public static T GetInChildrenIfNull<T>(this T obj, in Component context) where T : Component
            => GetInChildrenIfNull(obj: obj, context: context.gameObject);

        [PublicAPI]
        public static T TryGetIfNull<T>(this T obj, in Component context) where T : Component
            => TryGetIfNull(obj: obj, context: context.gameObject);

        [PublicAPI]
        public static T TryGetInChildrenIfNull<T>(this T obj, in Component context) where T : Component
            => TryGetInChildrenIfNull(obj: obj, context: context.gameObject);

        [PublicAPI]
        public static T TryGetInParentIfNull<T>(this T obj, in Component context) where T : Component
            => TryGetInParentIfNull(obj: obj, context: context.gameObject);

        [PublicAPI]
        public static T TryGetInParentOrChildrenIfNull<T>(this T obj, in Component context) where T : Component
            => TryGetInParentOrChildrenIfNull(obj: obj, context: context.gameObject);

        #endregion

        #endregion
    }
}