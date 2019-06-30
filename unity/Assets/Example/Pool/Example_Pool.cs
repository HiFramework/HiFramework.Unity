using System.Collections;
using System.Collections.Generic;
using HiFramework;
using HiFramework.Core;
using HiFramework.Unity;
using UnityEngine;

public class Example_Pool : MonoBehaviour
{
    IPool<Writer> _pool = new Pool<Writer>();

    private float _timeRate = 0.2f;

    private float _timeCounter = 0;

    // Use this for initialization
    void Start()
    {
        Center.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Center.Get<ITickComponent>().Tick(Time.deltaTime);
        _timeCounter += Time.deltaTime;
        if (_timeCounter > _timeRate)
        {
            _timeCounter = 0;
            var writer = _pool.GetOneObjectFromPool();
            //let writer do something that cost time, will reuse this write when it finish task
        }
    }

    private class Writer : IPoolObject
    {
        public void OnObjectCreate()
        {
        }

        public void OnObjectDispose()
        {
        }

        public void OnObjectInPool()
        {
        }

        public void OnObjectOutPool()
        {
        }
    }
}