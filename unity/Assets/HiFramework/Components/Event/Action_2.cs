/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    internal class Action_2<T, U> : ActionBase
    {
        private Action<T, U> _action;
        public Action_2(Action<T, U> action)
        {
            _action = action;
        }

        public override void Dispatch(params object[] objects)
        {
            if (objects != null && objects.Length == 2)
            {
                _action((T)objects[0], (U)objects[1]);
            }
            else
            {
                ParamMatchError();
            }
        }
    }
}
