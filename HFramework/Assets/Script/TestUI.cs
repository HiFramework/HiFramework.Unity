using UnityEngine;
using System.Collections;


using HiFramework;

public class TestUI : View
{

    // Use this for initialization
    void Start()
    {
        Register<Test2>(this);

        Test2.viewEventHandler = Log;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Log(Message msg)
    {
        Debug.Log(msg.ID);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 40), "click"))
        {
            Message me = new Message("111111111111");
            Facade.View.Dispatch<IView>(this, me);
        }
    }
}
