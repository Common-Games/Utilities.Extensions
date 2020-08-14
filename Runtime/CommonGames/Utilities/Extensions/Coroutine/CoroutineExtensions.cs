using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CommonGames.Utilities.Extensions
{

    public static partial class CoroutineExtensions
    {
        [PublicAPI]
        public static void Stop(this Coroutine coroutine, in MonoBehaviour behaviour)
        {
            if(coroutine != null)
                behaviour.StopCoroutine(routine: coroutine);
        }
    }
}