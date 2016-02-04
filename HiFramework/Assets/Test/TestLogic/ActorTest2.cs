using UnityEngine;
using System.Collections;

public class ActorTest2 : Actor
{

    void Start()
    {
        AddToTickList(this);
        Register<ActorControllerTest>();
    }

    public override void OnTick(float paramTime)
    {
        base.OnTick(paramTime);
        Debug.Log("from test2--------------" + paramTime);
    }
}