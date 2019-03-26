/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    public class SignalComponent : Component, ISignalComponent
    {
        Dictionary<string, SignalBase> _signals = new Dictionary<string, SignalBase>();


        /// <summary>
        /// Add signal to container
        /// </summary>
        /// <param name="key"></param>
        /// <param name="signal"></param>
        public void AddSignal(string key, SignalBase signal)
        {
            _signals.Add(key, signal);
        }

        /// <summary>
        /// Remove signal from container
        /// </summary>
        /// <param name="key"></param>
        public void RemoveSignal(string key)
        {
            var signal = _signals[key];
            signal.Dispose();
            _signals.Remove(key);
        }

        public SignalBase GetSignal(string key)
        {
            SignalBase signal = null;
            if (_signals.ContainsKey(key))
            {
                signal = _signals[key];
            }
            return signal;
        }
    }
}
