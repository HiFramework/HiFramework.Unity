//*********************************************************************
// Description:重新修改的float类型,自动忽略小数点后7位
// Author: hiramtan@live.com
//*********************************************************************
using System;

public struct HiFloat
{
    /// <summary>
    /// 保留小数点后6位,第7位四色五入
    /// </summary>
    private const int length = 6;
    private float value;
    private HiFloat(float param)
    {
        value = (float)Math.Round(param, length);
    }
    public static implicit operator HiFloat(float param)
    {
        return new HiFloat(param);
    }

    public static implicit operator float(HiFloat param)
    {
        return param.value;
    }

    public static HiFloat operator ++(HiFloat param)
    {
        return ++param.value;
    }

    public static HiFloat operator --(HiFloat param)
    {
        return --param.value;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is HiFloat))
        {
            throw new Exception("类型不一致");
        }
        HiFloat temp = (HiFloat)obj;
        if (temp.value == value)
            return true;
        return false;
    }
    public override string ToString()
    {
        return value.ToString();
    }
    public override int GetHashCode()
    {
        return value.GetHashCode();
    }
}