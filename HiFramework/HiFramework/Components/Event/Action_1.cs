/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    /// <summary>
    /// 一个参数类型的回调
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Action_1<T> : ActionBase
    {
        private Action<T> _action;
        public Action_1(Action<T> action)
        {
            _action = action;
        }

        public override void Dispatch(params object[] objects)
        {
            if (objects != null && objects.Length == 1 && objects[0] is T)
            {
                _action((T)objects[0]);
            }
            else
            {
                ParamMatchError();
            }
        }
    }
}