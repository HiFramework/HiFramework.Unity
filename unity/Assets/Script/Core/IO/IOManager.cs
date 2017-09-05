//****************************************************************************
// Description: 文件及文件夹的常用操作
// Author: hiramtan@live.com
//****************************************************************************

using System;
using System.IO;
using HiFramework.Core.AsyncTask;
using UnityEngine;

namespace HiFramework
{
    public class IoManager : Singleton<IoManager>
    {
        /// <summary>
        ///     文件夹是否存在
        /// </summary>
        /// <path name="path"></path>
        /// <returns></returns>
        public bool IsFolderExist(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        ///     创建文件夹
        ///     如果文件夹已存在则跳过
        /// </summary>
        /// <path name="path"></path>
        public void CreateFolder(string path)
        {
            if (!IsFolderExist(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        ///     复制文件夹
        ///     如果文件存在则覆盖
        /// </summary>
        /// <path name="sourcePath"></path>
        /// <path name="destinationPath"></path>
        public void CopyFolder(string sourcePath, string destinationPath)
        {
            if (!IsFolderExist(sourcePath))
            {
                Debug.Log("source folder not exist");
                return;
            }
            CreateFolder(destinationPath);
            var tempFiles = Directory.GetFiles(sourcePath);
            foreach (var variable in tempFiles)
            {
                var tempFileName = Path.GetFileName(variable);
                var tempDestName = Path.Combine(destinationPath, tempFileName);
                File.Copy(variable, tempDestName, true);
            }
            var tempDirs = Directory.GetDirectories(sourcePath);
            foreach (var variable in tempDirs)
            {
                var tempDirName = Path.GetFileName(variable);
                var tempDestDirName = Path.Combine(destinationPath, tempDirName);
                CopyFolder(variable, tempDestDirName);
            }
        }

        /// <summary>
        ///     递归删除文件夹
        /// </summary>
        /// <path name="path"></path>
        public void DeleteFolder(string path)
        {
            if (IsFolderExist(path))
                Directory.Delete(path, true); //第二个参数：删除子目录
        }

        /// <summary>
        ///     文件是否存在
        /// </summary>
        /// <path name="path"></path>
        /// <returns></returns>
        public bool IsFileExist(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        ///     读取文件
        /// </summary>
        /// <path name="path">传入路径及后缀</path>
        /// <returns></returns>
        public byte[] ReadFile(string path)
        {
            try
            {
                if (!IsFileExist(path))
                    return null;
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int) fs.Length);
                    fs.Close();
                    return bytes;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        /// <summary>
        ///     异步读取文件
        /// </summary>
        /// <path name="path">传入路径及后缀</path>
        /// <returns></returns>
        public byte[] ReadFileAsync(string path)
        {
            try
            {
                if (!IsFileExist(path))
                    return null;
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var bytes = new byte[fs.Length];
                    fs.BeginRead(bytes, 0, (int) fs.Length, temp =>
                    {
                        var tempFileStream = (FileStream) temp.AsyncState;
                        tempFileStream.EndRead(temp);
                        tempFileStream.Close();
                    }, fs);
                    return bytes;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        /// <summary>
        ///     写入文件
        ///     如果文件不存在,创建新文件写入
        ///     如果文件存在,追加写入
        /// </summary>
        /// <path name="path">传入路径及后缀</path>
        /// <path name="bytes"></path>
        public void WriteFile(string path, byte[] bytes)
        {
            try
            {
                var directory = Path.GetDirectoryName(path);
                CreateFolder(directory);
                using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Seek(0, SeekOrigin.End);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void WriteFileAsync(string path, byte[] bytes)
        {
            try
            {
                var directory = Path.GetDirectoryName(path);
                CreateFolder(directory);
                using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Seek(0, SeekOrigin.End);
                    fs.BeginWrite(bytes, 0, bytes.Length, temp =>
                    {
                        var tempFileStream = (FileStream) temp.AsyncState;
                        tempFileStream.EndWrite(temp);
                        tempFileStream.Close();
                    }, fs);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        /// <summary>
        ///     复制文件(覆盖的形式)
        /// </summary>
        /// <path name="sourcePath"></path>
        /// <path name="destinationPath"></path>
        public void CopyFile(string sourcePath, string destPath)
        {
            if (!IsFileExist(sourcePath))
            {
                Debug.Log("source file not exist");
                return;
            }
            var directory = Path.GetDirectoryName(destPath);
            CreateFolder(directory);
            File.Copy(sourcePath, destPath, true);
        }

        /// <summary>
        ///     删除文件
        /// </summary>
        /// <path name="path"></path>
        public void DeleteFile(string path)
        {
            if (IsFileExist(path))
                File.Delete(path);
        }

        public void ReadFileFromStreamingAssetsPath(string path, Action<WWW> handler)
        {
            path = GetStreamingAssetsPath() + "/" + path;

            new AsyncWwwTask(path).Start().OnFinish(x => { handler(x as WWW); });
        }

        public byte[] ReadFileFromPersistentDataPath(string path)
        {
            path = Application.persistentDataPath + "/" + path;
            return ReadFile(path);
        }

        public void WriteFileToPersistentDataPath(string path, byte[] bytes)
        {
            path = Application.persistentDataPath + "/" + path;
            WriteFile(path, bytes);
        }

        private string GetStreamingAssetsPath()
        {
#if UNITY_EDITOR || UNITY_IPHONE
            var path = "file://" + Application.streamingAssetsPath;
#else
                    string path = Application.streamingAssetsPath;
#endif
            return path;
        }
    }
}