/****************************************************************************
 * Description:封装常用异步任务
 *
 * Author: hiramtan@live.com
 ****************************************************************************/
using System.Collections.Generic;

namespace HiFramework
{
    public class AsyncComponent : Component, ITick
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

        public override void OnCreated()
        {
            Center.Get<TickComponent>().Regist(this);
        }

        public override void OnRemoved()
        {
            _iTicks.Clear();
        }
    }
}