//**************************0**************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
using System.Collections;

public class Manager
{
    //提供各种单例的集合,比如audiomanager



    protected AudioManager AudioManagerI { get { return AudioManager.Instance; } }
    protected IOManager IOManagerI { get { return IOManager.Instance; } }
}
public class Singletont<T> where T : new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }
}
