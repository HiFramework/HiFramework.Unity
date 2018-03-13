//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using HiFramework;
using System;

namespace HiFramework
{
    public unsafe class AsyncWaitTrueTask : AsyncTask
    {
        private Action _handler;
        private bool* _waitTrue;
        public AsyncWaitTrueTask(Action handler, ref bool waitTrue)
        {
            _handler = handler;
            fixed (bool* p = &waitTrue)
            {
                _waitTrue = p;
            }
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
        new AsyncWaitTrueTask(() => { UnityEngine.Debug.LogError("true"); }, ref test);
    }
}
