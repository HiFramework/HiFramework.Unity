//*********************************************************************
// Description:
// Author: hiramtan@live.com
//*********************************************************************
using HiFramework;
using UnityEngine;

public class Example : View
{
    // Use this for initialization
    void Start()
    {
        new GameObject("GameWorld").AddComponent<GameWorld>();

        Regist<Test1>("test1");

        Dispatch("test1");

        Facade.AgentMap.GetAgent<Test1>().Log();


        AddToTickList(this);

        Facade.Dispose();

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Test1 : Agent
{
    public void Log()
    {
        Debug.Log("from test1");
    }

    public override void OnTick()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnMessage(IMessage paramMessage)
    {
        Debug.Log("from message");
        // throw new System.NotImplementedException();
    }
}
