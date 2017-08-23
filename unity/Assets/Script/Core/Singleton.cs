//*********************************************************************
// Description:安全单例
// 提供两种类型的书写方式,如果类不能继承singleton<T>时,可以使用第二种方式快速提供单例
// Author: hiramtan@live.com
//*********************************************************************

using UnityEngine;

public class Singleton<T> where T : new()
{
    private static T instance;
    private static readonly object locker = new object();

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }
            }
            return instance;
        }
    }
}

public static class Singleton
{
    private static object locker = new object();

    public static T GetInstance<T>() where T : class, new()
    {
        if (InstanceStorage<T>.instance == null)
        {
            lock (locker)
            {
                if (InstanceStorage<T>.instance == null)
                {
                    InstanceStorage<T>.instance = new T();
                }
            }
        }
        return InstanceStorage<T>.instance;
    }

    private static class InstanceStorage<T> where T : class, new()
    {
        internal static volatile T instance = default(T);
    }
}

public class Singleton_Mono<T> : MonoBehaviour where T : Component
{
    private static object _lock = new object();
    private static T instance;

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] Something went really wrong " +
                                       " - there should never be more than 1 singleton!" +
                                       " Reopening the scene might fix it.");
                    }
                }
                if (instance == null)
                {
                    Debug.LogWarning("there is no this componet in scene, we will create one");
                    new GameObject("(singleton) " + typeof(T).ToString()).AddComponent<T>();
                }
                return instance;
            }
        }
    }
}



////example
//public class Test_First : Singleton<Test_First>
//{
//    public void Do() { }
//}

//public class Test_Second
//{
//    public void Do() { }
//}

//public class Test1
//{
//    void Init()
//    {
//        Test_First.Instance.Do();
//        Singleton.GetInstance<Test_Second>().Do();
//    }
//}