//*********************************************************************
// Description:重新修改的float类型,自动忽略小数点后7位
// Author: hiramtan@live.com
//*********************************************************************
using System;
namespace HiFramework
{
    public struct HiFloat
    {
        /// <summary>
        /// 保留小数点后6位,第7位四舍五入
        /// </summary>
        private const int Length = 6;
        private float _value;
        private HiFloat(float param)
        {
            _value = (float)Math.Round(param, Length);
        }
        public static implicit operator HiFloat(float param)
        {
            return new HiFloat(param);
        }

        public static implicit operator float(HiFloat param)
        {
            return param._value;
        }

        public static HiFloat operator ++(HiFloat param)
        {
            return ++param._value;
        }

        public static HiFloat operator --(HiFloat param)
        {
            return --param._value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is HiFloat))
            {
                throw new Exception("type not equal");
            }
            HiFloat temp = (HiFloat)obj;
            if (temp._value == _value)
                return true;
            return false;
        }
        public override string ToString()
        {
            return _value.ToString();
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
