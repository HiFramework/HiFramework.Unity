//****************************************************************************
// Description:游戏中的tick管理
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class GameTick : IGameTick
    {
        private IList<ITick> tickList = new List<ITick>();

        public GameTick()
        {
            tickList = new List<ITick>();
        }

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~GameTick()
        {
            Dispose(false);
        }
        private bool disposed;
        void Dispose(bool paramDisposing)
        {
            if (disposed)
                return;
            if (paramDisposing)
            {
                tickList = null;
            }
            disposed = true;
        }
    }
}