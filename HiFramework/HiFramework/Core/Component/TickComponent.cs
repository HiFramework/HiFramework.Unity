/****************************************************************************
 * Description: Manage tick logic 
 * 
 * Author: hiramtan@live.com
 ****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class TickComponent : Component
    {
        /// <summary>
        /// Component Inherited from ITick
        /// </summary>
        private List<ITick> ticks = new List<ITick>();

        /// <summary>
        /// When component created
        /// </summary>
        public override void OnCreated()
        {
            ticks = new List<ITick>();
        }

        /// <summary>
        /// When component removed
        /// </summary>
        public override void OnDestory()
        {
            ticks.Clear();
        }

        /// <summary>
        /// Regist Component who inherited from ITick
        /// </summary>
        /// <param name="iComponent"></param>
        public void Regist(IComponent iComponent)
        {
            if (iComponent is ITick)
            {
                var iTick = iComponent as ITick;
                AssertThat.IsFalse(ticks.Contains(iTick));
                ticks.Add(iTick);
            }
        }

        /// <summary>
        /// Remove from list
        /// </summary>
        /// <param name="iComponent"></param>
        public void Unregist(IComponent iComponent)
        {
            if (iComponent is ITick)
            {
                var iTick = iComponent as ITick;
                AssertThat.IsTrue(ticks.Contains(iTick));
                ticks.Remove(iTick);
            }
        }

        /// <summary>
        /// Run all tick
        /// </summary>
        public void Tick()
        {
            for (int i = 0; i < ticks.Count; i++)
            {
                ticks[i].Tick();
            }
        }
    }
}