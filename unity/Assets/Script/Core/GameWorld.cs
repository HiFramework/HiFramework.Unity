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
    private readonly List<Action> _applicationQuitActionList = new List<Action>();

    private static readonly object _locker = new object();
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
        {
            lock (_locker)
            {
                while (_toExecuteQueue.Count>0)
                {
                    var per = _toExecuteQueue.Dequeue();
                    per.Action(per.Obj);
                }
            }
        }

    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < _applicationQuitActionList.Count; i++)
        {
            _applicationQuitActionList[i]();
        }
    }

    public void OnApplicationQuit(Action action)
    {
        _applicationQuitActionList.Add(action);
    }

    void OnApplicationFocus(bool focus)
    {

    }

    void OnApplicationPause(bool pause)
    {

    }


    public void RunOnMainThread(Action<object> action, object obj)//obj不能可选为空,数据会被线程冲刷,需要传递原有数据
    {
        lock (_locker)
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