//****************************************************************************
// Description: 文件常用操作
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;

namespace HiFramework
{
    public interface IIO
    {
        #region folder
        /// <summary>
        /// 文件夹是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool IsFolderExist(string path);
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        void CreateFolder(string path);
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        void CopyFolder(string sourcePath, string destinationPath);
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path"></param>
        void DeleteFolder(string path);
        #endregion

        #region file
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool IsFileExist(string path);
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        byte[] ReadFile(string path);
        /// <summary>
        /// 异步读取文件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="path"></param>
        void ReadFileAsync(Action<byte[]> action, string path);
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        void WriteFile(string path, byte[] bytes);
        /// <summary>
        /// 异步写入文件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        void WriteFileAsync(Action action, string path, byte[] bytes);
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        void CopyFile(string sourcePath, string destPath);
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        void DeleteFile(string path);
        #endregion

        #region unity
        /// <summary>
        /// 从Streaming目录读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="action"></param>
        void ReadFileFromStreamingAssetsPath(string path, Action<WWW> action);
        /// <summary>
        /// 从Persistent目录读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        byte[] ReadFileFromPersistentDataPath(string path);
        /// <summary>
        /// 写入文件到Persistent目录
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        void WriteFileToPersistentDataPath(string path, byte[] bytes);
        #endregion
    }
}
