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
        private readonly List<ITick> ticks = new List<ITick>();

        public void RegistTick(ITick iTick)
        {
            ticks.Add(iTick);
        }

        public void UnRegistTick(ITick iTick)
        {
            ticks.Remove(iTick);
        }

        public void Tick(float deltaTime)
        {
            for (var i = 0; i < ticks.Count; i++)
                ticks[i].Tick(deltaTime);
        }

        public override void Dispose()
        {
            base.Dispose();
            ticks.Clear();
        }
    }
}