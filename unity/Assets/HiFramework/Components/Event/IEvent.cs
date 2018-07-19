/***************************************************************
 * Description: 
 * You can regist actions with same key, and this action will execute when this key dispatch.
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/
using System;

namespace HiFramework
{
    public interface IEvent
    {
        /// <summary>
        /// This is common use for five,six...even more param method, but you have to transfer param type by yourself
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        void Regist(string key, Action<object[]> action);

        /// <summary>
        /// Regist with no param action
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        void Regist(string key, Action action);

        /// <summary>
        /// Regist with one param action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        void Regist<T>(string key, Action<T> action);

        /// <summary>
        /// Regist with two params action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        void Regist<T, U>(string key, Action<T, U> action);

        /// <summary>
        /// Regist with three params action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        void Regist<T, U, V>(string key, Action<T, U, V> action);

        /// <summary>
        /// Regist with four params action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        void Regist<T, U, V, W>(string key, Action<T, U, V, W> action);

        /// <summary>
        /// Unregist key
        /// </summary>
        /// <param name="key"></param>
        void Unregist(string key);

        /// <summary>
        /// Remove one special event with same key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        void Unregist(string key, ActionBase action);

        /// <summary>
        /// Dispatch key and its action will execute
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        void Dispatch(string key, params object[] obj);
    }
}
