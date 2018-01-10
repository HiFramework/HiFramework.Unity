//****************************************************************************
// Description:
// Author: hiramtan@live.com
//***************************************************************************
using System.Collections.Generic;

namespace HiFramework
{
    class Ticker : Component, ITicker
    {
        private List<ITick> _iTicks = new List<ITick>();
        public Ticker(IContainer iContainer) : base(iContainer)
        {
            Regist(this);
        }
        public override void UnRegistComponent()
        {
            UnRegist(this);
        }

        public void Tick()
        {
            for (int i = 0; i < _iTicks.Count; i++)
            {
                _iTicks[i].Tick();
            }
        }
        public void Regist<T>(T t) where T : class, ITick
        {
            Assert.IsFalse(_iTicks.Contains(t));
            _iTicks.Add(t);
        }

        public void UnRegist<T>(T t) where T : class, ITick
        {
            Assert.IsTrue(_iTicks.Contains(t));
            _iTicks.Remove(t);
        }
    }
}