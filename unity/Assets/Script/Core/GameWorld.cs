//****************************************************************************
// Description:
// Author: hiramtan @live.com
//***************************************************************************

using HiFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

//thread
//public class GameWorld : Singleton_Mono<GameWorld>
public class GameWorld : MonoBehaviour
{
    public static GameWorld Instance;
    private static bool isExist;

    private Queue<ToExecute> toExecuteQueue = new Queue<ToExecute>();

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        if (!isExist)
        {
            DontDestroyOnLoad(gameObject);
            isExist = true;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Facade.GameTick.OnTick();
        if (toExecuteQueue.Count > 0)
        {
            lock (toExecuteQueue)
            {
                var per = toExecuteQueue.Dequeue();
                per.action(per.obj);
            }
        }
    }

    void OnApplicationQuit()
    {

    }

    public void RunOnMainThread(Action<object> action, object obj = null)
    {
        lock (toExecuteQueue)
        {
            toExecuteQueue.Enqueue(new ToExecute(action, obj));
        }
    }

    class ToExecute
    {
        public Action<object> action { get; private set; }
        public object obj { get; private set; }

        public ToExecute(Action<object> action, object obj)
        {
            this.action = action;
            this.obj = obj;
        }
    }
}


//public class Test
//{
//    private GameWorld gameWorld;
//    private GameObject go;
//    void Execute()
//    {
//        //线程中执行
//        gameWorld.RunOnMainThread((p) =>
//        {
//            //主线程中执行"
//            var t = go.GetComponent<Transform>();
//        }, null);
//    }
//}