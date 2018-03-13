//---------------------------------------------------------------------------------------------------
/*Description: 框架中tick维护组件
 * 驱动整个框架tick功能
 *  
 * Author: hiramtan@live.com
 */
//---------------------------------------------------------------------------------------------------



using System.Collections.Generic;

namespace HiFramework
{
    internal class Ticker : Component, ITicker
    {
        List<ITick> _iTicks = new List<ITick>();
        public Ticker(IContainer iContainer) : base(iContainer)
        {
        }

        public override void OnInit()
        {
        }

        public override void OnClose()
        {
            _iTicks.Clear();
        }
        public void Regist(IComponent iComponent)
        {
            if (iComponent is ITick)
            {
                var iTick = iComponent as ITick;
                Assert.IsFalse(_iTicks.Contains(iTick));
                _iTicks.Add(iTick);
            }
        }

        public void Unregist(IComponent iComponent)
        {
            if (iComponent is ITick)
            {
                var iTick = iComponent as ITick;
                Assert.IsTrue(_iTicks.Contains(iTick));
                _iTicks.Remove(iTick);
            }
        }

        public void Tick()
        {
            for (int i = 0; i < _iTicks.Count; i++)
            {
                _iTicks[i].Tick();
            }
        }
    }
}
