using UnityEngine;
using System.Collections;
using HFramework;
public class Test1 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {


        Message me = new Message("123");


        Debug.Log(Facade.Controller);


        Facade.Controller.Register(me, typeof(Test2));
        Facade.Controller.Execute(me);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
