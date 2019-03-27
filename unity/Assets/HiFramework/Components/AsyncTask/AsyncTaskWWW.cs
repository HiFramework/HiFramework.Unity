/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HiFramework
{
    class AsyncTaskWWW : TaskBase<WWW>
    {
        private WWW _www;

        public AsyncTaskWWW(Action<WWW> action, string url) : base(action)
        {
            Action = action;
            _www = new WWW(url);
        }

        public override void Tick(float time)
        {
            if (_www.isDone)
            {
                Finish();
                Action(_www);
            }
        }
    }
}