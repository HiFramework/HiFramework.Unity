//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System.Collections.Generic;

namespace HiFramework
{
    internal class AsyncComponent : Component, ITick, IAsyncComponent
    {
        private readonly List<ITick> _iTicks = new List<ITick>();

        public void RegistTick(ITick iTick)
        {
            _iTicks.Add(iTick);
        }

        public void UnRegistTick(ITick iTick)
        {
            _iTicks.Remove(iTick);
        }

        public void Tick()
        {
            for (var i = 0; i < _iTicks.Count; i++)
                _iTicks[i].Tick();
        }

        public AsyncComponent(IContainer iContainer) : base(iContainer)
        {
            Center.RegistTick(this);
        }

        public override void UnRegistComponent()
        {
            _iTicks.Clear();
            Center.UnRegistTick(this);
        }
    }
}