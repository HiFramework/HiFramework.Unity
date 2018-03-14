#### 项目介绍
基于组件的项目管理框架,使用如下:
```csharp
        IIO io = Center.Get<IOComponent>();
        var file = io.ReadFile("path");
```


#### 使用方法

从此地址下载unitypackage:[![Github Releases](https://img.shields.io/github/downloads/atom/atom/total.svg)](https://github.com/hiramtan/HiFramework_unity/releases) 

-----
#### 框架介绍


框架分为三层:
- Core
 
    框架基础逻辑,包含组件维护,Tick管理.
- Extensions
 
    常用功能扩展
- Components

    组件
    
组件在初次调用时初始化并缓存供再次使用,组件之间各自独立存在.框架会在组件创建时调用OnInit方法,组件销毁时调用OnClose方法.
#### 组件介绍
框架中已封装一部分常用组件,列表如下:

1. 异步任务
    1. 获取网络Ping值
    2. 定时重复执行
    3. 异步加载
    4. 定时执行
    5. 检测变量值变化
    6. WWW下载
2. 事件系统
3. 属性注入
4. 文件管理
5. 主线程切换
6. 网络模块
7. 对象池
8. 消息系统
9. 压缩模块
10. 加密模块


----
#### 组件扩展
开发者可以基于框架方便的扩展自己的组件,使用框架维护项目模块.
扩展组件需要继承Component类,并且需要实现OnInit()和OnClose()方法.
- OnInit() 在组件初始化时执行.
- OnClose() 在组件销毁时执行.

