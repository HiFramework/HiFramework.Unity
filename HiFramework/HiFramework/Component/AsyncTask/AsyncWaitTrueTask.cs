//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HiFramework;

namespace HiFramework
{
    public unsafe class AsyncWaitTrueTask : AsyncTask
    {
        private Action _handler;
        private bool* _waitTrue;
        public AsyncWaitTrueTask(Action handler, bool* waitTrue)
        {
            _handler = handler;
            _waitTrue = waitTrue;
        }

        protected override bool IsDone { get; set; }
        protected override void OnTick()
        {
            if (*_waitTrue)
            {
                IsDone = true;
            }
        }

        protected override void Done()
        {
            _handler();
        }
    }
}

public class TestAsyncWaitTrueTask
{
    bool test = false;
    void Main()
    {
        unsafe
        {
            unsafe
            {
                fixed (bool* p = &test)
                {
                    new AsyncWaitTrueTask(() => { UnityEngine.Debug.LogError("true"); }, p);
                }
            }
        }
    }
}
