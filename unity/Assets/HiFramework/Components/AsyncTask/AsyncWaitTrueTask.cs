////****************************************************************************
//// Description: 异步任务:检测如果是true时响应
//// unsafe 
//// 需要项目允许unsafe代码
//// Author: hiramtan@live.com
////****************************************************************************

//using HiFramework;
//using System;

//namespace HiFramework
//{
//    public unsafe class AsyncWaitTrueTask : AsyncTaskNoParam
//    {
//        private bool* _waitTrue;
//        public AsyncWaitTrueTask(Action handler, ref bool waitTrue) : base(handler)
//        {
//            fixed (bool* p = &waitTrue)
//            {
//                _waitTrue = p;
//            }
//        }

//        public override void Tick()
//        {
//            if (*_waitTrue)
//            {
//                Done();
//            }
//        }
//    }
//}

//public class TestAsyncWaitTrueTask
//{
//    bool test = false;
//    void Main()
//    {
//        //Log will print if test's value change to true
//        new AsyncWaitTrueTask(() => { UnityEngine.Debug.Log("true"); }, ref test);
//    }
//}
