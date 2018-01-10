//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;

namespace HiFramework
{
    interface IIO
    {
        #region folder
        bool IsFolderExist(string path);
        void CreateFolder(string path);
        void CopyFolder(string sourcePath, string destinationPath);
        void DeleteFolder(string path);
        #endregion
        
        #region file
        bool IsFileExist(string path);
        byte[] ReadFile(string path);
        void ReadFileAsync(Action<byte[]> action, string path);
        void WriteFile(string path, byte[] bytes);
        void WriteFileAsync(Action action, string path, byte[] bytes);
        void CopyFile(string sourcePath, string destPath);
        void DeleteFile(string path);
        #endregion
        
        #region unity
        void ReadFileFromStreamingAssetsPath(string path, Action<WWW> action);
        byte[] ReadFileFromPersistentDataPath(string path);
        void WriteFileToPersistentDataPath(string path, byte[] bytes);
        #endregion
    }
}
