/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    internal class Action_4<T, U, V, W> : ActionBase
    {
        private Action<T, U, V, W> _action;
        public Action_4(Action<T, U, V, W> action)
        {
            _action = action;
        }

        public override void Dispatch(params object[] objects)
        {
            if (objects != null && objects.Length == 4)
            {
                _action((T)objects[0], (U)objects[1], (V)objects[2], (W)objects[3]);
            }
            else
            {
                ParamMatchError();
            }
        }
    }
}
