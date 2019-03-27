/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;

namespace HiFramework
{
    class SignalComponent : ComponentBase, ISignalComponent
    {
        Dictionary<Type, object> signals = new Dictionary<Type, object>();
        public override void OnCreated()
        {
        }

        public override void Dispose()
        {
        }

        public T GetSignal<T>() where T : class
        {
            var key = typeof(T);
            if (signals.ContainsKey(key))
            {
                return signals[key] as T;
            }
            return CreateSignal(key) as T;
        }

        public void RemoveSignal<T>() where T : class
        {
            var key = typeof(T);
            AssertThat.IsTrue(signals.ContainsKey(key), "Do not have this signal");
            signals.Remove(key);
        }

        private object CreateSignal(Type key)
        {
            var signal = Activator.CreateInstance(key);
            AssertThat.IsNotNull(signal, "Create signal faild");
            signals[key] = signal;
            return signal;
        }
    }
}
