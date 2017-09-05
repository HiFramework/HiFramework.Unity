//****************************************************************************
// Description:游戏中的tick管理
// Author: hiramtan@live.com
//****************************************************************************
using System.Collections.Generic;

namespace HiFramework
{
    public class GameTick :ObjectBase, ITick
    {
        private IList<ITick> _tickList = new List<ITick>();

        public void OnTick()
        {
            for (int i = 0; i < _tickList.Count; i++)
                _tickList[i].OnTick();
        }

        public void AddToTickList(ITick iTick)
        {
            if (!_tickList.Contains(iTick))
                _tickList.Add(iTick);
        }
        public void RemoveFromTickList(ITick iTick)
        {
            if (_tickList.Contains(iTick))
                _tickList.Remove(iTick);
        }

        protected override void OnDispose()
        {
            _tickList.Clear();
            _tickList = null;
        }
    }
}