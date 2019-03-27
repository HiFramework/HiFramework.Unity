﻿/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.IO;

namespace HiFramework
{
    class IOComponent : ComponentBase, IIOComponent
    {
        public bool IsFolderExist(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateFolder(string path)
        {
            AssertThat.IsFalse(IsFileExist(path));
            Directory.CreateDirectory(path);
        }

        public void CopyFolder(string sourcePath, string destinationPath)
        {
            AssertThat.IsTrue(IsFileExist(sourcePath));
            AssertThat.IsFalse(IsFileExist(destinationPath));
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
            AssertThat.IsTrue(IsFolderExist(path));
            Directory.Delete(path, true); //第二个参数：删除子目录
        }

        public bool IsFileExist(string path)
        {
            return File.Exists(path);
        }

        public byte[] ReadFile(string path)
        {
            AssertThat.IsTrue(IsFileExist(path));
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int) fs.Length);
                fs.Close();
                return bytes;
            }
        }

        public void ReadFileAsync(Action<byte[]> action, string path)
        {
            AssertThat.IsTrue(IsFileExist(path));
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.BeginRead(bytes, 0, (int) fs.Length, temp =>
                {
                    var tempFileStream = (FileStream) temp.AsyncState;
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
                    var tempFileStream = (FileStream) temp.AsyncState;
                    tempFileStream.EndWrite(temp);
                    tempFileStream.Close();
                    action();
                }, fs);
            }
        }

        public void CopyFile(string sourcePath, string destPath)
        {
            AssertThat.IsTrue(IsFileExist(sourcePath));
            AssertThat.IsFalse(IsFileExist(destPath));
            var directory = Path.GetDirectoryName(destPath);
            CreateFolder(directory);
            File.Copy(sourcePath, destPath, true);
        }

        public void DeleteFile(string path)
        {
            AssertThat.IsTrue(IsFileExist(path));
            File.Delete(path);
        }

        public override void OnCreated()
        {
        }

        public override void Dispose()
        {
        }
    }
}