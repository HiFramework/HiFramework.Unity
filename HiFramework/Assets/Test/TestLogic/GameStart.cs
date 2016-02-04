using UnityEngine;
using System.Collections;
using HiFramework;
public class GameStart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        new GameObject("GameWorld").AddComponent<GameWorld>();
        Facade.Mediator.Register<GameStartCommand>(TestCommand.Start);


        Message msg = new Message("Start");
        Facade.Mediator.Dispatch(TestCommand.Start, msg);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
