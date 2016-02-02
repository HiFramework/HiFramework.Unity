using UnityEngine;
using System.Collections;
using HiFramework;
public class Test1 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {



        Facade.Controller.Register<Test2>("123");


        Message me = new Message("123");
        Facade.Controller.Dispatch<string>("123", me);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
