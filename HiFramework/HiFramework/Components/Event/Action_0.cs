/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    /// <summary>
    /// 无参数回调
    /// </summary>
    internal class Action_0 : ActionBase
    {
        private Action _action;
        public Action_0(Action action)
        {
            _action = action;
        }

        public override void Dispatch(params object[] objects)
        {
            if (objects == null || objects.Length == 0)
            {
                _action();
            }
            else
            {
                ParamMatchError();
            }
        }
    }
}