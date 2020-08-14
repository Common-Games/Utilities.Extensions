using UnityEngine;

using JetBrains.Annotations;

namespace CommonGames.Utilities.Extensions
{

    public static partial class AnimationCurveExtensions
    {
        [PublicAPI]
        public static float TimeFromValue(this AnimationCurve animationCurve, in float value, in float precision = 1e-6f)
        {
            float __minTime = animationCurve.keys[0].time;
            float __maxTime = animationCurve.keys[animationCurve.keys.Length-1].time;
            
            float __best = (__maxTime + __minTime) / 2;
            float __bestVal = animationCurve.Evaluate(__best);
            
            int __iterations = 0;
            
            const int __MAX_ITERATIONS = 1000;
            
            float __sign = Mathf.Sign(animationCurve.keys[animationCurve.keys.Length-1].value -animationCurve.keys[0].value);
            
            while(__iterations < __MAX_ITERATIONS && Mathf.Abs(__minTime - __maxTime) > precision) 
            {
                if((__bestVal - value) * __sign > 0) 
                {
                    __maxTime = __best;
                } 
                else 
                {
                    __minTime = __best;
                }
                
                __best = (__maxTime + __minTime) / 2;
                __bestVal = animationCurve.Evaluate(__best);
                __iterations++;
            }
            
            return __best;
        }
    }
}
