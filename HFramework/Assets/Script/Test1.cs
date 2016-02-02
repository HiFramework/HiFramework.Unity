using UnityEngine;
using System.Collections;
using HiFramework;
public class Test1 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {



        Facade.Controller.Register<Test2>("123");


        Message msg = new Message("123");
        Facade.Controller.Dispatch<string>("123", msg);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
