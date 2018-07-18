/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/



using System.Collections.Generic;
using System.Linq;

namespace HiFramework
{

    public class SignalComponent : Component, ISignalComponent
    {
        List<SignalBase> _signals = new List<SignalBase>();
        public void AddSignal(SignalBase iSignal)
        {
            HiAssert.IsFalse(_signals.Contains(iSignal));
            _signals.Add(iSignal);
        }
        public void RemoveSignal(SignalBase iSignal)
        {
            HiAssert.IsTrue(_signals.Contains(iSignal));
            _signals.Remove(iSignal);
        }
        public override void OnDestory()
        {
            base.OnDestory();
            _signals.Clear();
        }
    }
}
