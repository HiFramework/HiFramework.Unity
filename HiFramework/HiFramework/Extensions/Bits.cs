/***************************************************************
 * Description: 字节位逻辑
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;
using System.Collections;

namespace HiFramework
{
    public class Bits
    {
        private byte[] _bytes;
        private BitArray _bitArray;
        private const int BitsOfOneByte = 8;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitCount">how many bit</param>
        public Bits(int bitCount = BitsOfOneByte)
        {
            if (bitCount <= 0)
            {
                throw new Exception("bit count can not less or equal 0");
            }
            var @base = bitCount / BitsOfOneByte;
            var left = bitCount % BitsOfOneByte;
            var length = left == 0 ? @base : @base + 1;
            if (length <= 0)
            {
                throw new Exception("byte array can not less or equal 0");
            }
            _bytes = new byte[length];
            _bitArray = new BitArray(_bytes);
        }

        /// <summary>
        /// 设置某个游标对应的值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetBit(int index, bool value)
        {
            if (index >= _bitArray.Count)
            {
                throw new IndexOutOfRangeException("index out of range");
            }
            _bitArray[index] = value;
        }

        /// <summary>
        /// 获取某个游标对应值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetBit(int index)
        {
            if (index >= _bitArray.Count)
            {
                throw new IndexOutOfRangeException("index out of range");
            }
            return _bitArray[index];
        }

        /// <summary>
        /// 向左移位
        /// </summary>
        /// <param name="count"></param>
        public void MoveLeft(int count)
        {
            BitArray b = new BitArray(_bitArray.Length);
            for (int i = count, j = 0; i < b.Length; i++, j++)
            {
                b[i] = _bitArray[j];
            }
            _bitArray = b;
        }

        /// <summary>
        /// 与运算
        /// </summary>
        /// <param name="bites"></param>
        /// <returns></returns>
        public Bits And(Bits bits)
        {
            _bitArray.And(bits._bitArray);
            return this;
        }

        /// <summary>
        /// 或运算
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public Bits Or(Bits bits)
        {
            _bitArray.Or(bits._bitArray);
            return this;
        }

        /// <summary>
        /// 向右移位
        /// </summary>
        public void MoveRight(int count)
        {
            BitArray b = new BitArray(_bitArray.Length);
            for (int i = b.Length - count, j = _bitArray.Length; i > 0; i--, j--)
            {
                b[i - 1] = _bitArray[j - 1];
            }
            _bitArray = b;
        }

        /// <summary>
        /// 获取比特值
        /// </summary>
        /// <returns>比特值</returns>
        public string GetString()
        {
            string s = "";
            for (int i = _bitArray.Length; i > 0; i--)
            {
                var value = _bitArray[i - 1] ? 1 : 0;
                s += value;
            }
            return s;
        }
    }
}

//void Start()
//{
//    Bits bits = new Bits(10);
//    bits.SetBit(3, true);
//    Debug.Log("初始化: " + bits.GetString());
//    bits.MoveLeft(5);
//    Debug.Log("向左移5位: " + bits.GetString());
//    bits.MoveRight(5);
//    Debug.Log("向右移5位: " + bits.GetString());

//    Debug.LogError("开始与或运算");
//    var test = new Bits(10);
//    test.SetBit(5, true);
//    Debug.Log("初始化: " + test.GetString());
//    test.And(bits);
//    Debug.Log("与运算:" + test.GetString());
//    test.SetBit(5, true);
//    test.Or(bits);
//    Debug.Log("或运算:" + test.GetString());
//}