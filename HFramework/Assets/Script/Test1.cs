using UnityEngine;
using System.Collections;
using HiFramework;
public class Test1 : MonoBehaviour
{

    void Awake()
    {
        Facade.Controller.Register<Test2>(EnumCommand.StartGame.ToString());
    }

    // Use this for initialization
    void Start()
    {
        Message msg = new Message("test1", "test1body", CallBack);

        Facade.Controller.Dispatch<string>(EnumCommand.StartGame.ToString(), msg);
    }

    void CallBack(Message paramMessage)
    {
        Debug.Log("call back: " + paramMessage.ID + paramMessage.Body);
    }


}
