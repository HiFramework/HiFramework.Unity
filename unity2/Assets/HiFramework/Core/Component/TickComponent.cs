using System;
using System.Collections.Generic;

namespace HiFramework
{
    class TickComponent : Component, ITickComponent
    {
        private readonly List<ITick> _ticks = new List<ITick>();
        public override void OnCreated()
        {
        }

        public override void Dispose()
        {
            _ticks.Clear();
        }

        public void Tick(float time)
        {
            for (int i = 0; i < _ticks.Count; i++)
            {
                var tick = _ticks[i];
                AssertThat.IsNotNull(tick, "Tick list has null component");
                tick.Tick(time);
            }
        }

        public void Regist<T>(T t) where T : ITick, new()
        {
            AssertThat.IsFalse(_ticks.Contains(t), "Tick list alreay has this component");
            _ticks.Add(t);
        }

        public void Unregist<T>(T t) where T : ITick, new()
        {
            AssertThat.IsTrue(_ticks.Contains(t), "Tick list do not have this component");
            _ticks.Remove(t);
        }
    }
}
