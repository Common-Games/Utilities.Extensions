using System;

using JetBrains.Annotations;

namespace CommonGames.Utilities.Extensions
{
    public static partial class LogicExtensions
    {

        /// <summary> Do action(s) with target item. </summary>
        [PublicAPI]
        public static void Do<T>(this T t, params Action<T>[] actions) => actions.For(action: x => x(obj: t));

        /// <summary> If bool is true, execute action. </summary>
        [PublicAPI]
        public static void If(this bool b, in Action action)
        {
            if(b)
            {
                action();
            }
        }

        /// <summary> Executes the first action on true, the second on false. </summary>
        [PublicAPI]
        public static void IfElse(this bool checkIfTrue, in Action onTrue, in Action onFalse)
        {
            if(checkIfTrue)
            {
                onTrue();
            }
            else
            {
                onFalse();
            }
        }

        /// <summary> Execute target action <param name="index"></param> times where func returns true with overload <param name="index"></param>. </summary>
        [PublicAPI]
        public static void For(this int index, Func<int, bool> func, Action<int> action)
        {
            for(int __indexer = 0; __indexer < index; __indexer++)
            {
                if(func(arg: index))
                {
                    action(obj: index);
                }
            }
        }

        /// <summary> Execute target function i times. </summary>
        [PublicAPI]
        public static void For(this int index, in Action action)
        {
            for(int __indexer = 0; __indexer < index; __indexer++)
            {
                action();
            }
        }

        /// <summary> Execute target function i times, with the index as overload. </summary>
        [PublicAPI]
        public static void For(this int index, in Action<int> action)
        {
            for(int __indexer = 0; __indexer < index; __indexer++)
            {
                action(obj: __indexer);
            }
        }
    }
}