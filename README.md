# HiFramework_unity

#### 项目介绍
基于组件的项目管理框架,使用如下:
```csharp
        var io = Center.Get<IOComponent>();
        var file = io.ReadFile("path");
```


#### 使用方法

- dll的方式(包含示例)

    从此地址下载unitypackage:[![Github Releases](https://img.shields.io/github/downloads/atom/atom/total.svg)](https://github.com/hiramtan/HiFramework_unity/releases) 
- 源码的方式

    导入Visual工程源码


允许工程使用**unsafe**代码(有对指针进行操作).


-----

#### 组件列表
框架中已封装一部分常用组件,列表如下:

1. 异步任务   
2. 事件系统
3. 依赖注入
4. 文件管理
5. 主线程切换
6. 网络模块
7. 对象池
8. 消息系统
9. 压缩模块
10. 加密模块

#### 组件介绍
##### 异步任务
    1. 获取网络Ping值

 ``` csharp
            new AsyncRepeatingPingTask(x =>
            {
                string log = "current ping is: " + x;
            }, "ip", 1);
 ```
    2. 定时重复执行
 ```csharp
            new AsyncRepeatingTask(() =>
            {
                string log = "execute";
            }, 1);
 ```
    3. 异步加载
```csharp
            new AsyncResourceLoadTask((x)=>
            {
               var go= UnityEngine.Object.Instantiate(x) as GameObject;
            },"path");
```
    4. 定时执行
```csharp
            new AsyncTimeTask(()=>
            {
                string log = "execute";
            },1);
```
    5. 检测变量值变化
```csharp
      bool test = false;
       void Main()
       {
           new AsyncWaitTrueTask(() => { UnityEngine.Debug.LogError("true"); }, ref test);
       }
```
    6. WWW下载
```csharp
            new AsyncWWWTask((x) =>
            {
                string log = x.bytes.ToString();
            }, "url");
```
##### 事件系统
```csharp
        public void TestMethod()
        {
            IEvent iEvent = Center.Get<EventComponent>();
            iEvent.Regist("key", Handler);
            iEvent.Dispatch("key", 1, "hello");
        }
        void Handler(object[] args)
        {
            var t = (int)args[0];
            var tt = (string)args[1];
            Assert.IsTrue(t == 1);
            Assert.IsTrue(tt == "hello");
        }
```
##### 依赖注入
```csharp
        public void TestMethod()
        {
            Test test = new Test();

            IBinder i = Center.Get<BinderComponent>();
            var test1 = new Test1();
            i.Bind<ITest>().To(test1).AsName("test1");
            var test2 = new Test2();
            i.Bind<ITest>().To(test2).AsName("test2");
            i.SetUp();

            i.Inject(test);
            Assert.IsTrue(test.test1.GetType().Name == "Test1");
            Assert.IsTrue(test.test2.GetType().Name == "Test2");
        }
        class Test
        {
            [Inject("test1")]
            public ITest test1;

            [Inject("test2")]
            public ITest test2;
        }
```
##### 文件管理
``` csharp
        var io = Center.Get<IOComponent>();
        var file = io.ReadFile("path");
```
```csharp
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
```
##### 主线程切换
```csharp
            string ss = "this run on thread";
            var c = Center.Get<MainThreadComponent>();
            c.RunOnMainThread(x =>
            {
                string s = "this run on main thread";
            },null);
```
##### 网络模块
##### 对象池
```csharp
        public void TestMethod()
        {
            var pool = new Pool<GameObject>(new GameObjectHandler());
            var go = pool.Get();
            pool.Reclaim(go);
        }
        class GameObjectHandler : IPoolHandler<GameObject>
        {
            public GameObject Create()
            {
                return UnityEngine.Object.Instantiate(Resources.Load("")) as GameObject;
            }

            public void Destory(GameObject obj)
            {
                Destory(obj);
            }

            public void InToPool(GameObject args)
            {
                args.SetActive(false);
            }

            public void OutFromPool(GameObject args)
            {
                args.SetActive(true);
            }
        }
```
#### 消息系统
```csharp
        public void TestMethod()
        {
            Signal noparam = new Signal();
            noparam.Regist(Hanlder);
            noparam.Dispatch();

            Signal<int, string> withParam = new Signal<int, string>();
            withParam.Regist(HandlerWithParam);
            withParam.Dispatch(1, "hello");
        }
        void Hanlder()
        {
            string log = "execute";
        }
        void HandlerWithParam(int x, string y)
        {
            string log = "execute" + x + y;
        }
```



----

#### 框架介绍


框架分为三层:
- Core
 
    框架基础逻辑,包含组件维护,Tick管理.
- Extensions
 
    常用功能扩展
- Components

    组件
    
组件在初次调用时初始化并缓存供再次使用,组件之间各自独立存在.

框架会在组件创建时调用OnInit方法,组件销毁时调用OnClose方法.

#### 组件扩展
开发者可以基于框架方便的扩展自己的组件,使用框架维护项目模块.

扩展组件需要继承Component类,并且需要实现OnInit()和OnClose()方法.

support: hiramtan@live.com


***********

MIT License

Copyright (c) [2017] [Hiram]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
