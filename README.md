# HiFramework_unity

![Packagist](https://img.shields.io/packagist/l/doctrine/orm.svg)   [![GitHub release](https://img.shields.io/github/release/hiramtan/HiFramework_unity.svg)](https://github.com/hiramtan/HiFramework_unity/releases)


-----------------------

#### 如何使用
[![Github Releases](https://img.shields.io/github/downloads/atom/atom/total.svg)](https://github.com/hiramtan/HiFramework_unity/releases) 

从此地址下载dll,复制到项目中:

``` csharp
        var io = Center.Get<IIOComponent>();
        io.ReadFile("path");
```

#### 简介
- 基于接口实现:不关心具体实现只使用接口调用,方便快速替换实现方案
- 基于组件实现:各功能模块组件相互独立不干扰
- 基于绑定实现:用户可以自定义接口绑定实现
- 可扩展:方便添加删除组件,即便是默认绑定组件用户也可以重写方法替换或删除
- 逻辑分层:核心,组件,扩展

#### 功能预览
- 核心:已完成
- 组件:
  - 异步任务
  - 事件
  - 注入
  - 消息
  - 对象池
  - 文件输入输出
- 扩展:
  - 比特位扩展
  - 裁剪Float类型
  - 快速列表





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
