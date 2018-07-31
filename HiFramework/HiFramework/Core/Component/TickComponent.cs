/****************************************************************************
 * Description: Manage tick logic 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class TickComponent : Component, ITick
    {
        /// <summary>
        /// Component Inherited from ITick
        /// </summary>
        private List<ITick> ticks;

        /// <summary>
        /// When component created
        /// </summary>
        public override void OnCreated()
        {
            ticks = new List<ITick>();
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public override void Dispose()
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
        /// Tick method to run all tick Components
        /// </summary>
        public void Tick(float deltaTime)
        {
            for (int i = 0; i < ticks.Count; i++)
            {
                ticks[i].Tick(deltaTime);
            }
        }
    }
}