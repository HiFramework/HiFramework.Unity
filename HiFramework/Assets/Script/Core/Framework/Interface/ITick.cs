﻿//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
namespace HiFramework
{
    public interface ITick
    {
        void AddToTickList(ITick paramTick);
        void RemoveFromTickList(ITick paramTick);
        void OnTick();
    }
}