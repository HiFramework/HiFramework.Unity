//****************************************************************************
// Description: 文件及文件夹的常用操作
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.IO;
using UnityEngine;
namespace HiFramework
{
    public class IoManager : Singleton<IoManager>
    {
        /// <summary>
        /// 文件夹是否存在
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool IsFolderExist(string param)
        {
            return Directory.Exists(param);
        }
        /// <summary>
        /// 创建文件夹
        /// 如果文件夹已存在则跳过
        /// </summary>
        /// <param name="param"></param>
        public void CreateFolder(string param)
        {
            if (!IsFolderExist(param))
                Directory.CreateDirectory(param);
        }

        /// <summary>
        /// 复制文件夹
        /// 如果文件存在则覆盖
        /// </summary>
        /// <param name="paramSourcePath"></param>
        /// <param name="paramDestPath"></param>
        public void CopyFolder(string paramSourcePath, string paramDestPath)
        {
            if (!IsFolderExist(paramSourcePath))
            {
                Debug.Log("source folder not exist");
                return;
            }
            CreateFolder(paramDestPath);
            var tempFiles = Directory.GetFiles(paramSourcePath);
            foreach (var variable in tempFiles)
            {
                var tempFileName = Path.GetFileName(variable);
                var tempDestName = Path.Combine(paramDestPath, tempFileName);
                File.Copy(variable, tempDestName, true);
            }
            var tempDirs = Directory.GetDirectories(paramSourcePath);
            foreach (var variable in tempDirs)
            {
                string tempDirName = Path.GetFileName(variable);
                string tempDestDirName = Path.Combine(paramDestPath, tempDirName);
                CopyFolder(variable, tempDestDirName);
            }
        }

        /// <summary>
        /// 递归删除文件夹
        /// </summary>
        /// <param name="param"></param>
        public void DeleteFolder(string param)
        {
            if (IsFolderExist(param))
                Directory.Delete(param, true);//第二个参数：删除子目录
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool IsFileExist(string param)
        {
            return File.Exists(param);
        }
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="param">传入路径及后缀</param>
        /// <returns></returns>
        public byte[] ReadFile(string param)
        {
            try
            {
                if (!IsFileExist(param))
                    return null;
                using (FileStream fs = new FileStream(param, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
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
        /// 异步读取文件
        /// </summary>
        /// <param name="param">传入路径及后缀</param>
        /// <returns></returns>
        public byte[] ReadFileAsync(string param)
        {
            try
            {
                if (!IsFileExist(param))
                    return null;
                using (FileStream fs = new FileStream(param, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.BeginRead(bytes, 0, (int)fs.Length, (temp) =>
                    {
                        FileStream tempFileStream = (FileStream)temp.AsyncState;
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
        /// 写入文件
        /// 如果文件不存在,创建新文件写入
        /// 如果文件存在,追加写入
        /// </summary>
        /// <param name="paramPath">传入路径及后缀</param>
        /// <param name="paramBytes"></param>
        public void WriteFile(string paramPath, byte[] paramBytes)
        {
            try
            {
                string directory = Path.GetDirectoryName(paramPath);
                CreateFolder(directory);
                using (FileStream fs = new FileStream(paramPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Seek(0, SeekOrigin.End);
                    fs.Write(paramBytes, 0, paramBytes.Length);
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void WriteFileAsync(string paramPath, byte[] paramBytes)
        {
            try
            {
                string directory = Path.GetDirectoryName(paramPath);
                CreateFolder(directory);
                using (FileStream fs = new FileStream(paramPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Seek(0, SeekOrigin.End);
                    fs.BeginWrite(paramBytes, 0, paramBytes.Length, (temp) =>
                          {
                              FileStream tempFileStream = (FileStream)temp.AsyncState;
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
        /// 复制文件(覆盖的形式)
        /// </summary>
        /// <param name="paramSourcePath"></param>
        /// <param name="paramDestPath"></param>
        public void CopyFile(string paramSourcePath, string paramDestPath)
        {
            if (!IsFileExist(paramSourcePath))
            {
                Debug.Log("source file not exist");
                return;
            }
            string directory = Path.GetDirectoryName(paramDestPath);
            CreateFolder(directory);
            File.Copy(paramSourcePath, paramDestPath, true);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="param"></param>
        public void DeleteFile(string param)
        {
            if (IsFileExist(param))
                File.Delete(param);
        }

        public void ReadFileFromStreamingAssetsPath(string paramPath, Action<WWW> paramHandler)
        {
            paramPath = GetStreamingAssetsPath() + "/" + paramPath;

            new AsyncWwwTask(paramPath).Start().OnFinish((x) => { paramHandler(x as WWW); });
        }

        public byte[] ReadFileFromPersistentDataPath(string param)
        {
            param = Application.persistentDataPath + "/" + param;
            return ReadFile(param);
        }

        public void WriteFileToPersistentDataPath(string paramPath, byte[] paramBytes)
        {
            paramPath = Application.persistentDataPath + "/" + paramPath;
            WriteFile(paramPath, paramBytes);
        }

        private string GetStreamingAssetsPath()
        {
#if UNITY_EDITOR || UNITY_IPHONE
            string path = "file://" + Application.streamingAssetsPath;
#else
                    string path = Application.streamingAssetsPath;
#endif
            return path;
        }
    }
}