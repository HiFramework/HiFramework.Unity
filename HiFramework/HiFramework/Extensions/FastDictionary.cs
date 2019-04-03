/****************************************************************************
 * Description:Fast dictionary logic and not use lingQ
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    public class FastDictionary<T1, T2>
    {
        /// <summary>
        /// key-value
        /// </summary>
        private Dictionary<T1, T2> keyValue = new Dictionary<T1, T2>();

        /// <summary>
        /// value-key
        /// </summary>
        private Dictionary<T2, T1> valueKey = new Dictionary<T2, T1>();

        public T2 this[T1 index]
        {
            get { return keyValue[index]; }
            set
            {
                keyValue[index] = value;
                valueKey[value] = index;
            }
        }

        /// <summary>
        /// Add into dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(T1 key, T2 value)
        {
            keyValue.Add(key, value);
            valueKey.Add(value, key);
        }

        /// <summary>
        /// Remove from dictionary
        /// </summary>
        /// <param name="key"></param>
        public void Remove(T1 key)
        {
            var value = keyValue[key];
            keyValue.Remove(key);
            valueKey.Remove(value);
        }

        /// <summary>
        /// Get key by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T1 GetKeyByValue(T2 value)
        {
            return valueKey[value];
        }

        /// <summary>
        /// Try Get Value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(T1 key, out T2 value)
        {
            return keyValue.TryGetValue(key, out value);
        }

        /// <summary>
        /// If contain
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(T1 key)
        {
            return keyValue.ContainsKey(key);
        }

        /// <summary>
        /// If contain
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue(T2 value)
        {
            return keyValue.ContainsValue(value);
        }

        /// <summary>
        /// Clear the dictionary
        /// </summary>
        public void Clear()
        {
            keyValue.Clear();
            valueKey.Clear();
        }

        class Example
        {
            FastDictionary<string, int> nameAndAge = new FastDictionary<string, int>();
            void Test()
            {
                var t = nameAndAge[""];
                var key = nameAndAge.GetKeyByValue(t);
            }
        }
    }
}

