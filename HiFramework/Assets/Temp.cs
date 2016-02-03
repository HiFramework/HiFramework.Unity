using UnityEngine;
using System.Collections;
using System;

public class Temp : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 40), "click"))
        {
            Type type = this.GetType();
            object obj = Activator.CreateInstance(type);
            ((Temp)obj).Log();
        }
    }

    public void Log()
    {
        Debug.Log("test");
    }
}
