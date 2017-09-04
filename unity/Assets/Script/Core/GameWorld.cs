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
    private static bool _isExist;

    private Queue<ToExecute> _toExecuteQueue = new Queue<ToExecute>();

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        if (!_isExist)
        {
            DontDestroyOnLoad(gameObject);
            _isExist = true;
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
        if (_toExecuteQueue.Count > 0)
        {
            lock (_toExecuteQueue)
            {
                var per = _toExecuteQueue.Dequeue();
                per.Action(per.Obj);
            }
        }
    }

    void OnApplicationQuit()
    {

    }

    public void RunOnMainThread(Action<object> action, object obj = null)
    {
        lock (_toExecuteQueue)
        {
            _toExecuteQueue.Enqueue(new ToExecute(action, obj));
        }
    }

    class ToExecute
    {
        public Action<object> Action { get; private set; }
        public object Obj { get; private set; }

        public ToExecute(Action<object> action, object obj)
        {
            this.Action = action;
            this.Obj = obj;
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