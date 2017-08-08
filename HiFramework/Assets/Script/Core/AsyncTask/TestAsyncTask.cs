using HiFramework;
using UnityEngine;

public class TestAsyncTask : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        new AsyncTask().Start();
        new AsyncTask().Start().Finish(TaskFinish);
    }

    void TaskFinish(object param)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
