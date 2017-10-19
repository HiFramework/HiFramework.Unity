//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//***************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        internal void MakeTick(IComponet iComponet)
        {
            var iTick = iComponet as ITick;
            if (iTick == null)
                return;
            if (iTicks.Contains(iTick))
                return;
            iTicks.Add(iTick);
        }
    }
}
