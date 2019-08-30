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
    public class Fsm : IFsm
    {
        /// <summary>
        /// Current state
        /// </summary>
        public IState CurrentState
        {
            get { return _currentState; }
        }

        private StateBase _currentState;
        private IStateChangeRule _rule;
        private Dictionary<string, StateBase> _states = new Dictionary<string, StateBase>();

        public Fsm(IStateChangeRule rule)
        {
            this._rule = rule;
        }

        /// <summary>
        /// Init regist state and it's name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="state"></param>
        public void RegistState(StateBase state)
        {
            _states.Add(state.Name, state);
        }

        /// <summary>
        /// Init state machine
        /// </summary>
        /// <param name="stateName"></param>
        public void Init(string stateName)
        {
            StateBase state;
            var isTrue = _states.TryGetValue(stateName, out state);
            if (isTrue)
            {
                _currentState = state;
                _currentState.Init();
            }
            else
            {
                //regist first
            }
        }

        /// <summary>
        /// Change state
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(string stateName)
        {
            StateBase state;
            var isTrue = _states.TryGetValue(stateName, out state);
            if (isTrue)
            {
                var isCanChange = _rule.IsCanChangeState(CurrentState, state);
                if (isCanChange)
                {
                    _currentState.Exit();
                    _currentState = state;
                    _currentState.Init();
                }
                else
                {
                    //can not change
                }
            }
            else
            {
                //regist first
            }
        }

        /// <summary>
        /// Tick logic
        /// </summary>
        /// <param name="time"></param>
        public void Tick(float time)
        {
            if (_currentState != null)
            {
                _currentState.Tick(time);
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
            _currentState = null;
            _states.Clear();
        }
    }
}
