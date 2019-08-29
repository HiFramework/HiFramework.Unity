/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework.Unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework.Unity
{
    public abstract class StateBase : IState
    {
        protected IFsm Fsm;

        public string Name { get; }

        public StateBase(string stateName, Fsm fsm)
        {
            Name = stateName;
            this.Fsm = fsm;
        }

        public abstract void Init();
        public abstract void Tick(float time);
        public abstract void Exit();

        protected void ChangeState(string stateName)
        {
            Fsm.ChangeState(stateName);
        }
    }
}
