using HiFramework;
using UnityEngine;

/// <summary>
/// 测试逻辑,测试异步计数
/// </summary>
public class AsyncCountTask : AsyncTask
{
    private int i = 0;

    protected override void Update()
    {
        i++;
        if (i > 100)
            isDone = true;
    }
}


//public class TestAsyncCountTask : MonoBehaviour
//{
//    void Start()
//    {
//        //启动异步计数,不需要回调(比如复制文件,完成后不需要回调)
//        new AsyncCountTask().Start();
//    }
//}

//public class TestAsyncCountTask : MonoBehaviour
//{
//    void Start()
//    {
//        //启动异步计数,捕获完成事件
//        new AsyncCountTask().Start().Finish(Finish);
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
//        new AsyncCountTask().Start().Finish((p) =>
//        {
//            Debug.Log("finish");
//        });
//    }
//}
