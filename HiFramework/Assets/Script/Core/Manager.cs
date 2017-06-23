//**************************0**************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
using System.Collections;

/// <summary>
/// 提供各种单例的集合,比如audiomanager
/// </summary>
public class Manager
{
    protected AudioManager AudioManagerI { get { return AudioManager.Instance; } }
    protected IOManager IOManagerI { get { return IOManager.Instance; } }
}
