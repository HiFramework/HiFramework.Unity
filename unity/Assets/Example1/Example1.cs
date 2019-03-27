using HiFramework;
using UnityEngine;

public class Example1 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Center.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Center.Tick(Time.deltaTime);
    }
}
