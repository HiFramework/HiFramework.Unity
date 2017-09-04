//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
using System.Collections;
using System;

public class WwwLoader : MonoBehaviour
{
    private static WwwLoader _instance;
    public static WwwLoader Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameObject("WWWLoader").AddComponent<WwwLoader>();
            return _instance;
        }
    }
    public void Startload(string downloadUrl, Action<WWW> callBackHandler = null)
    {
        lock(this)
        {
            StartCoroutine(Load(downloadUrl, callBackHandler));
        }
    }
    private IEnumerator Load(string downloadUrl, Action<WWW> callBackHandler)
    {
        WWW www = new WWW(downloadUrl);
        while (!www.isDone)
            yield return www;
        if (callBackHandler != null)
            callBackHandler(www);
    }
}
