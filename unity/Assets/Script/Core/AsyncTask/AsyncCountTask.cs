//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************


namespace HiFramework
{/// <summary>
 /// 测试逻辑,测试异步计数
 /// </summary>
    public class AsyncCountTask : AsyncTask
    {
        private int _i;
        private int _total;
        public AsyncCountTask(int total)
        {
            _total = total;
        }

        protected override void Tick()
        {
            _i++;
            if (_i > _total)
                IsDone = true;
        }

        protected override void Complate()
        {
            Action(null);
        }
    }
}


//public class TestAsyncCountTask : MonoBehaviour
//{
//    void Start()
//    {
//        //启动异步计数,不需要回调(比如复制文件,完成后不需要回调)
//        new AsyncCountTask(10).Start();
//    }
//}

//public class TestAsyncCountTask : MonoBehaviour
//{
//    void Start()
//    {
//        //启动异步计数,捕获完成事件
//        new AsyncCountTask(10).Start().OnFinish(Finish);
//    }

//    void Finish(object param)
//    {
//        Debug.Log("finish");
//    }
//}

//public class TestAsyncCountTask : MonoBehaviour
//{
//    void Start()
//    {
//        //启动异步计数,捕获完成事件
//        new AsyncCountTask(10).Start().OnFinish((p) =>
//        {
//            Debug.Log("finish");
//        });
//    }
//}
