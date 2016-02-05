using UnityEngine;
using System.Collections;

public class ActorTest : Actor
{
    public ActorTest(GameObject paramGo) : base(paramGo)
    {
    }


    public override void OnTick()
    {
        Debug.LogError(Time.deltaTime);
    }
}
