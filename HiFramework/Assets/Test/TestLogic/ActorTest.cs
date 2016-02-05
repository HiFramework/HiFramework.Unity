using UnityEngine;
using System.Collections;

public class ActorTest : Actor
{
    public ActorTest(GameObject paramGo) : base(paramGo)
    {
        view = new ActorViewTest(this, paramGo);
        data = new ActorDataTest(this);




        Test();//for test
    }

    public override void OnTick()
    {
        Debug.LogError(Time.deltaTime);
    }

    void Test()
    {

        //基础方法提取到父类view中,比如move
        ((ActorViewTest)view).Move();
    }
}
