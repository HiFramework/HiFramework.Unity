using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using HiFramework;
using Assert = NUnit.Framework.Assert;

public class TestMain : IPrebuildSetup
{
    private GameObject go;
    public void Setup()
    {
        new GameObject("Framework").AddComponent<TestMainMonoBehaviour>();
    }
}
public class TestMainMonoBehaviour : MonoBehaviour, IMonoBehaviourTest
{
    private int frameCount;
    public bool IsTestFinished
    {
        get { return frameCount > 100000; }
    }

    void Awake()
    {
        Framework.Init();
    }

    void Update()
    {
        frameCount++;
        Framework.Tick();
    }
}
