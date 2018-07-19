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
        List<SignalBase> _signals = new List<SignalBase>();
        public void AddSignal(SignalBase iSignal)
        {
            AssertThat.IsFalse(_signals.Contains(iSignal));
            _signals.Add(iSignal);
        }
        public void RemoveSignal(SignalBase iSignal)
        {
            AssertThat.IsTrue(_signals.Contains(iSignal));
            _signals.Remove(iSignal);
        }
        public override void OnDestory()
        {
            base.OnDestory();
            _signals.Clear();
        }
    }
}
