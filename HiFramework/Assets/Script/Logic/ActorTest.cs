using UnityEngine;
using System.Collections;

public class ActorTest : Actor
{
    void Start()
    {
        Init();

        controller = new ActorControllerTest(this);


        ((ActorControllerTest)controller).TestController();








    }
}