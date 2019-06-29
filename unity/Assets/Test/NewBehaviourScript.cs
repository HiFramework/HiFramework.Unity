using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Debug.LogError("start");
        File.Create(Application.dataPath + "/test.bin");
    }

    // Update is called once per frame
    void Update()
    {


    }
}