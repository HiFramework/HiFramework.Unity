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
    /// 通用回调（需要自己转换类型）
    /// </summary>
    internal class Action_ObjectArray : ActionBase
    {
        private Action<object[]> _action;
        public Action_ObjectArray(Action<object[]> action)
        {
            _action = action;
        }

        public override void Dispatch(params object[] objects)
        {
            //if (objects != null && objects.Length != 0)
            _action(objects);
        }
    }
}
