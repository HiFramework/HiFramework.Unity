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
        Dictionary<string, SignalBase> signals = new Dictionary<string, SignalBase>();


        /// <summary>
        /// Add signal to container
        /// </summary>
        /// <param name="key"></param>
        /// <param name="signal"></param>
        public void AddSignal(string key, SignalBase signal)
        {
            signals.Add(key, signal);
        }

        /// <summary>
        /// Get signal 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SignalBase GetSignal(string key)
        {
            return signals[key];
        }

        /// <summary>
        /// Remove signal from container
        /// </summary>
        /// <param name="key"></param>
        public void RemoveSignal(string key)
        {
            var signal = signals[key];
            signal.Dispose();
            signals.Remove(key);
        }
    }
}
