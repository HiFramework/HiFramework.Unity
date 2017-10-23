//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//***************************************************************************
using System.Collections.Generic;

namespace HiFramework
{
    class Ticker : ITick
    {
        private List<ITick> _iTicks = new List<ITick>();
        public void Tick()
        {
            for (int i = 0; i < _iTicks.Count; i++)
            {
                _iTicks[i].Tick();
            }
        }

        internal void RegistTick(IComponent iComponent)
        {
            var iTick = iComponent as ITick;
            if (iTick == null)
                return;
            if (_iTicks.Contains(iTick))
                return;
            _iTicks.Add(iTick);
        }
        internal void UnRegistTick(IComponent iComponent)
        {
            var iTick = iComponent as ITick;
            if (iTick == null)
                return;
            Assert.IsTrue(_iTicks.Contains(iTick));
            _iTicks.Remove(iTick);
        }
    }
}