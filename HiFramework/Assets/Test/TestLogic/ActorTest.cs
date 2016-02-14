using UnityEngine;
using System.Collections;

public class ActorTest : Actor
{
    public ActorTest(GameObject paramGo) : base(paramGo)
    {
        view = new ActorViewTest(this, paramGo);
        data = new ActorDataTest(this);


    }

    public override void OnTick()
    {
       // ((ActorViewTest)view).OnTick();

        view.OnTick();
    }

    void Test()
    {

        //基础方法提取到父类view中,比如move
        //((ActorViewTest)view).Move();



        view.OnTick();
    }
}
