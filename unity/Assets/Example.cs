//*********************************************************************
// Description:
// Author: hiramtan@live.com
//*********************************************************************
using HiFramework;
using UnityEngine;

public class Example : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

        //new GameObject("GameTick").AddComponent<GameTick>();


        //var tt = Facade.Map.Regist<tt>("12345");


        //tt test = Facade.Map.GetAgent(typeof(tt).FullName) as tt;

        //test.Log();


        //Facade.Dispose();

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class tt : Agent
{
    public void Log()
    {
        Debug.Log("from tt");


    }

    public override void OnTick()
    {
        throw new System.NotImplementedException();
    }

    public override void OnMessage(IMessage paramMessage)
    {
        Debug.Log("from message");
        // throw new System.NotImplementedException();
    }
}
