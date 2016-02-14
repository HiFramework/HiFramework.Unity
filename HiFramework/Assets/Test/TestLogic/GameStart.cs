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


        Facade.Mediator.Dispatch(TestCommand.Start);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
