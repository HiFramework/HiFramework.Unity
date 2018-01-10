
//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.IO;
using UnityEngine;

namespace HiFramework
{
    class IOComponent : Component, IIO
    {
        public bool IsFolderExist(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateFolder(string path)
        {
            Assert.IsFalse(IsFileExist(path));
            Directory.CreateDirectory(path);
        }

        public void CopyFolder(string sourcePath, string destinationPath)
        {
            Assert.IsTrue(IsFileExist(sourcePath));
            Assert.IsFalse(IsFileExist(destinationPath));
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

        public void DeleteFolder(string path)
        {
            Assert.IsTrue(IsFolderExist(path));
            Directory.Delete(path, true); //第二个参数：删除子目录
        }

        public bool IsFileExist(string path)
        {
            return File.Exists(path);
        }

        public byte[] ReadFile(string path)
        {
            Assert.IsTrue(IsFileExist(path));
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                fs.Close();
                return bytes;
            }
        }

        public void ReadFileAsync(Action<byte[]> action, string path)
        {
            Assert.IsTrue(IsFileExist(path));
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.BeginRead(bytes, 0, (int)fs.Length, temp =>
                {
                    var tempFileStream = (FileStream)temp.AsyncState;
                    tempFileStream.EndRead(temp);
                    tempFileStream.Close();
                    action(bytes);
                }, fs);
            }
        }

        public void WriteFile(string path, byte[] bytes)
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

        public void WriteFileAsync(Action action, string path, byte[] bytes)
        {
            var directory = Path.GetDirectoryName(path);
            CreateFolder(directory);
            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Seek(0, SeekOrigin.End);
                fs.BeginWrite(bytes, 0, bytes.Length, temp =>
                {
                    var tempFileStream = (FileStream)temp.AsyncState;
                    tempFileStream.EndWrite(temp);
                    tempFileStream.Close();
                    action();
                }, fs);
            }
        }

        public void CopyFile(string sourcePath, string destPath)
        {
            Assert.IsTrue(IsFileExist(sourcePath));
            Assert.IsFalse(IsFileExist(destPath));
            var directory = Path.GetDirectoryName(destPath);
            CreateFolder(directory);
            File.Copy(sourcePath, destPath, true);
        }

        public void DeleteFile(string path)
        {
            Assert.IsTrue(IsFileExist(path));
            File.Delete(path);
        }

        public void ReadFileFromStreamingAssetsPath(string path, Action<WWW> action)
        {
            path = GetStreamingAssetsPath() + "/" + path;
            new AsyncWWWTask((x) => { action(x as WWW); }, path);
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

        public IOComponent(IContainer iContainer) : base(iContainer)
        {
        }

        public override void UnRegistComponent()
        {
        }
    }
}
