using UnityEngine;
using System.Collections;
using HiFramework;
public class GameStart : MonoBehaviour
{
    void Start()
    {
        new GameObject(Common.gameworldName).AddComponent<Gameworld>();



        Facade.Controller.Register<TestController>(EnumCommand.StartGame.ToString());



        Message msg = new Message("method1","test1", CallBack);
        Facade.Controller.Dispatch<string>(EnumCommand.StartGame.ToString(), msg);
    }

    void CallBack(Message paramMessage)
    {
        Debug.Log("call back: " + paramMessage.Body);
    }
}