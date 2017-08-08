using HiFramework;
using UnityEngine;

public class AsyncWWWTask : AsyncTask
{
    private WWW www;
    public AsyncWWWTask(string url)
    {
        www = new WWW(url);
    }

    protected override void Update()
    {
        Debug.Log(www.progress);

        if (www.isDone)
            isDone = true;
    }

    protected override void _Complate()
    {
        action(www);
    }
}

//public class TestAsyncWWWTask : MonoBehaviour
//{
//    void Start()
//    {
//        string url = "www.g.com";
//        new AsyncWWWTask(url).Start().Finish((p) =>
//        {
//            Debug.Log("download finish:" + ((WWW)p).bytes);
//        });
//    }
//}