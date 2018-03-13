/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;

namespace HiFramework
{
   public interface ISignalComponent
    {
        void AddSignal(SignalBase iSignal);
        void RemoveSignal(SignalBase iSignal);
    }
    class SignalComponent : Component, ISignalComponent
    {
        List<SignalBase> _signals = new List<SignalBase>();

        public void AddSignal(SignalBase iSignal)
        {
            Assert.IsFalse(_signals.Contains(iSignal));
            _signals.Add(iSignal);
        }

        public void RemoveSignal(SignalBase iSignal)
        {
            Assert.IsTrue(_signals.Contains(iSignal));
            _signals.Remove(iSignal);
        }
        public SignalComponent(IContainer iContainer) : base(iContainer)
        {
        }

        public override void UnRegistComponent()
        {
            _signals.Clear();
        }
    }
}
