/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework.Unity
 * Author: hiramtan@live.com
 ****************************************************************************/
using System.Collections.Generic;
using HiFramework;

namespace HiFramework.Unity
{
    class TickComponent : ComponentBase, ITickComponent
    {
        private readonly List<ITick> _ticks = new List<ITick>();
        public override void OnCreated()
        {

        }

        public override void OnDestroy()
        {
            _ticks.Clear();
        }

        public void Tick(float time)
        {
            for (int i = 0; i < _ticks.Count; i++)
            {
                var tick = _ticks[i];
                Assert.IsNotNull(tick, "Tick list has null componentBase");
                tick.Tick(time);
            }
        }

        public void Regist<T>(T t) where T : ITick
        {
            Assert.IsFalse(_ticks.Contains(t), "Tick list alreay has this componentBase");
            _ticks.Add(t);
        }

        public void Unregist<T>(T t) where T : ITick
        {
            Assert.IsTrue(_ticks.Contains(t), "Tick list do not have this componentBase");
            _ticks.Remove(t);
        }
    }
}
