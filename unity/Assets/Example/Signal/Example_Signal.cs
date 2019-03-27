using System.Collections;
using System.Collections.Generic;
using HiFramework;
using UnityEngine;

public class Example_Signal : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Center.Init();

        var signalComponent = Center.Get<ISignalComponent>();
        var signal = signalComponent.GetSignal<Example_Signal_Score>();
        signal.AddListener(OnSignal);
        signal.Fire(100);
    }

    // Update is called once per frame
    void Update()
    {
        Center.Tick(Time.deltaTime);
    }

    void OnSignal(int score)
    {
        Debug.Log(score);
    }
}