//****************************************************************************
// Description:
// Author: hiramtan @live.com
//***************************************************************************

using System;
using System.Collections.Generic;
using HiFramework;
using UnityEngine;

//thread
//public class GameWorld : Singleton_Mono<GameWorld>
public class GameWorld : MonoBehaviour
{
    public static GameWorld Instance;
    private static bool _isExist;

    private readonly Queue<ToExecute> _toExecuteQueue = new Queue<ToExecute>();

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    private void Start()
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
    private void Update()
    {
        Facade.GameTick.OnTick();
        if (_toExecuteQueue.Count > 0)
            lock (_toExecuteQueue)
            {
                var per = _toExecuteQueue.Dequeue();
                per.Action(per.Obj);
            }
    }

    private void OnApplicationQuit()
    {
    }

    public void RunOnMainThread(Action<object> action, object obj = null)
    {
        lock (_toExecuteQueue)
        {
            _toExecuteQueue.Enqueue(new ToExecute(action, obj));
        }
    }

    private class ToExecute
    {
        public ToExecute(Action<object> action, object obj)
        {
            Action = action;
            Obj = obj;
        }

        public Action<object> Action { get; private set; }
        public object Obj { get; private set; }
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