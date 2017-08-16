//****************************************************************************
// Description:游戏中的tick管理
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class GameTick :ObjectBase, ITick
    {
        private IList<ITick> tickList = new List<ITick>();

        public void OnTick()
        {
            for (int i = 0; i < tickList.Count; i++)
                tickList[i].OnTick();
        }

        public void AddToTickList(ITick paramTick)
        {
            if (!tickList.Contains(paramTick))
                tickList.Add(paramTick);
        }
        public void RemoveFromTickList(ITick paramTick)
        {
            if (tickList.Contains(paramTick))
                tickList.Remove(paramTick);
        }

        protected override void OnDispose()
        {
            tickList.Clear();
            tickList = null;
        }
    }
}