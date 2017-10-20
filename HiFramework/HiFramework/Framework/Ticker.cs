//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//***************************************************************************
using System.Collections.Generic;

namespace HiFramework
{
    class Ticker : ITick
    {
        private List<ITick> iTicks = new List<ITick>();
        public void Tick()
        {
            for (int i = 0; i < iTicks.Count; i++)
            {
                iTicks[i].Tick();
            }
        }

        internal void RegistTick(IComponent iComponent)
        {
            var iTick = iComponent as ITick;
            if (iTick == null)
                return;
            if (iTicks.Contains(iTick))
                return;
            iTicks.Add(iTick);
        }
        internal void UnRegistTick(IComponent iComponent)
        {
            var iTick = iComponent as ITick;
            if (iTick == null)
                return;
            Assert.isTrue(iTicks.Contains(iTick));
            iTicks.Remove(iTick);
        }
    }
}