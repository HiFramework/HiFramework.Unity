//*********************************************************************
// Description:
// Author: hiramtan@live.com
//*********************************************************************


using System;
using UnityEngine;
using UnityEngine.Networking;

public struct HiFloat : IEquatable<HiFloat>
{
    //保留小数点后6位,第7位四色五入
    public const int length = 6;
    private float hiValue;
    private HiFloat(float param)
    {
        hiValue = (float)Math.Round(param, 6);
    }
    public bool Equals(HiFloat param)
    {
        throw new NotImplementedException();
    }

    public static implicit operator HiFloat(float param)
    {
        return new HiFloat(param);
    }

    public static implicit operator float(HiFloat param)
    {
        return param.hiValue;
    }

    public static HiFloat operator ++(HiFloat param)
    {
        float test = param.hiValue++;
        return test;
    }


    //public static implicit operator HiFloat(float value)
    //{
    //    ObscuredFloat obscured = new ObscuredFloat(InternalEncrypt(value));
    //    if (onCheatingDetected != null)
    //    {
    //        obscured.fakeValue = value;
    //    }
    //    return obscured;
    //}

    //public static implicit operator float(HiFloat value)
    //{
    //    return value.InternalDecrypt();
    //}
}

public class tst
{

    HiFloat test = 2;
}