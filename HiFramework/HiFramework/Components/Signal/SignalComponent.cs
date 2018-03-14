/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////



using System.Collections.Generic;
using System.Linq;

namespace HiFramework
{
    
    internal class SignalComponent : Component, ISignalComponent
    {
        Dictionary<string, SignalBase> _signals = new Dictionary<string, SignalBase>();

        public void AddSignal(string key, SignalBase iSignal)
        {
            Assert.IsFalse(_signals.Keys.Contains(key));
            _signals.Add(key, iSignal);
        }

        public SignalBase GetSignal(string key)
        {
            Assert.IsTrue(_signals.Keys.Contains(key));
            return _signals[key];
        }

        public void RemoveSignal(string key)
        {
            Assert.IsTrue(_signals.Keys.Contains(key));
            _signals.Remove(key);
        }
        public SignalComponent(IContainer iContainer) : base(iContainer)
        {
        }

        public override void OnInit()
        {
        }

        public override void OnClose()
        {
            _signals.Clear();
        }
    }
}
