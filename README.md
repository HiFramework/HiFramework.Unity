# HiFramework_unity

based on [https://github.com/hiramtan/HiFramework](https://github.com/hiramtan/HiFramework)

![Packagist](https://img.shields.io/packagist/l/doctrine/orm.svg)   [![GitHub release](https://img.shields.io/github/release/hiramtan/HiFramework_unity.svg)](https://github.com/hiramtan/HiFramework_unity/releases)


-----------------------

#### 如何使用

- 下载
  - 源码: HiFramework/HiFramework
  - Dll: [![Github Releases](https://img.shields.io/github/downloads/atom/atom/total.svg)](https://github.com/hiramtan/HiFramework_unity/releases) 
  
- 使用
``` csharp
        var io = Center.Get<IIOComponent>();
        io.ReadFile("path");
```

#### 简介

##### 概述:基于接口的组件维护框架,内置了常用的几个组件和扩展,支持用户添加自定义组件.

- 基于接口实现:不关心具体实现只使用接口调用,方便快速替换实现方案
- 基于组件实现:各功能模块组件相互独立不干扰
- 基于绑定实现:用户可以自定义接口绑定实现
- 可扩展:方便添加删除组件,即便是默认绑定组件用户也可以重写方法替换或删除
- 逻辑分层:核心,组件,扩展

#### 功能预览
- 核心
- 组件:
  - 异步任务
  - 事件
  - 注入
  - 消息
  - 对象池
  - 文件操作
- 扩展:
  - 比特位扩展
  - 裁剪Float类型
  - 快速列表

#### 自定义组件


```csharp
 public override void Init()
    {
        base.Init();
        Bind<Example_Bind_ITest>().To<Example_Bind_ITestComponent>();
    }
```

#### 示例

更多示例在:unity/Assets/Example

- 异步任务
  - 延迟执行
    ```csharp
        void Start()
        {
            Center.Init();
            new AsyncTaskWaitTime(OnLog,    10);
        }    
        // Update is called once per frame
        void Update()
        {
            Center.Tick(Time.deltaTime);
        }    
        void OnLog()
        {
            Debug.Log("wait for 10s");
        }
    ```
  - 定时器
    ```csharp
     void Start()
     {
         Center.Init();    
         var task = new AsyncTaskRepea         (OnLog,   2);
         //task.Stop();
     }    
     // Update is called once per frame
     void Update()
     {
         Center.Tick(Time.deltaTime);
     }    
     void OnLog()
     {
         Debug.Log("log every 2s");
     }
    ```
- 事件
  
```csharp
Center.Init();
        var eventComponent = Center.Get<IEventComponent>();
        eventComponent.Subscribe<int>("key", OnEvent);

        eventComponent.Dispatch("key", 100);
```

- 注入

```csharp
        Center.Init();
        var inject = Center.Get<IInjectComponent>();
        inject.Bind<Example_Inject>().To(this);

        var newClass = new Example_Inject_NewClass();
        inject.Inject(newClass);
        newClass.Log();
```
- 消息
  ```csharp
        var signalComponent = Center.Get<ISignalComponent>();
        var signal = signalComponent.GetSignal<Example_Signal_Score>();
        signal.AddListener(OnSignal);
        signal.Fire(100);
```
- 对象池
  ```csharp
        Center.Tick(Time.deltaTime);
        _timeCounter += Time.deltaTime;
        if (_timeCounter > _timeRate)
        {
            _timeCounter = 0;
            var writer = _pool.GetOneObjectFromPool();
            //let writer do something that cost time, will reuse this write when it finish task
        }
```




#### wiki
旧文档：(更多文档查看wiki: [https://github.com/hiramtan/HiFramework_unity/wiki](https://github.com/hiramtan/HiFramework_unity/wiki) ):




点击链接加入QQ群【83596104】：https://jq.qq.com/?_wv=1027&k=5l6rZEr

support: hiramtan@live.com

-----------------

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
