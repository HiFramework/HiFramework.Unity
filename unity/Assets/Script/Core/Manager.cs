//**************************0**************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using UnityEngine;
using System.Collections;
using HiFramework;

/// <summary>
/// 提供各种单例的集合,比如audiomanager
/// </summary>
public class Manager
{
    protected AudioManager AudioManagerI { get { return AudioManager.Instance; } }
    protected IoManager IoManagerI { get { return IoManager.Instance; } }
}
