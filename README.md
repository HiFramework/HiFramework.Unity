# HiFramework_unity

haven't finished yet
#### 项目介绍
基于组件的项目管理框架,使用如下:
```csharp
        var io = Center.Get<IOComponent>();
        var file = io.ReadFile("path");
```


#### 使用方法

从此地址下载unitypackage:[![Github Releases](https://img.shields.io/github/downloads/atom/atom/total.svg)](https://github.com/hiramtan/HiFramework_unity/releases) 

-----

#### 组件列表
框架中已封装一部分常用组件,列表如下:

1. 异步任务   
2. 事件系统
3. 属性注入
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
    4. 定时执行
    5. 检测变量值变化
    6. WWW下载
##### 事件系统
```csharp
        public void TestMethod()
        {
            Signal noparam = new Signal("firstone");
            noparam.Regist(Hanlder);
            noparam.Dispatch();

            Signal<int, string> withParam = new Signal<int, string>("secondone");
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
