﻿/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    /// <summary>
    /// Reuse array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICircullarBuffer<T> : IDisposable
    {
        /// <summary>
        /// Array to contain element
        /// </summary>
        T[] Array { get; }

        /// <summary>
        /// Capacity
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Current read and write state
        /// </summary>
        CircullarBuffer<T>.State EState { get; }

        /// <summary>
        /// Index of read position
        /// </summary>
        int ReadPosition { get; }

        /// <summary>
        /// Index of write postion
        /// </summary>
        int WritePosition { get; }

        /// <summary>
        /// how many data can write into array
        /// </summary>
        int HowManyCanWrite { get; }

        /// <summary>
        /// How many data wait read
        /// </summary>
        int HowManyCanRead { get; }

        /// <summary>
        /// Move read index
        /// </summary>
        /// <param name="length"></param>
        void MoveReadPosition(int length);

        /// <summary>
        /// Move write index
        /// </summary>
        /// <param name="length"></param>
        void MoveWritePosition(int length);

        /// <summary>
        /// Write all data to array
        /// </summary>
        /// <param name="bytes"></param>
        void Write(T[] bytes);

        /// <summary>
        /// Read all from array
        /// </summary>
        /// <returns></returns>
        T[] Read();
    }
}
