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
        private List<ITick> _iTicks = new List<ITick>();

        /// <summary>
        /// When component created
        /// </summary>
        public override void OnCreated()
        {
            _iTicks = new List<ITick>();
        }

        /// <summary>
        /// When component removed
        /// </summary>
        public override void OnRemoved()
        {
            _iTicks.Clear();
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
                HiAssert.IsFalse(_iTicks.Contains(iTick));
                _iTicks.Add(iTick);
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
                HiAssert.IsTrue(_iTicks.Contains(iTick));
                _iTicks.Remove(iTick);
            }
        }

        /// <summary>
        /// Run all tick
        /// </summary>
        public void Tick()
        {
            for (int i = 0; i < _iTicks.Count; i++)
            {
                _iTicks[i].Tick();
            }
        }
    }
}