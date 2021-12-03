# 89Test05技术文档

1、功能概述

- 实现阶梯奖励领取功能
- 涉及知识点：逻辑，视图分离的思想，委托的使用。



2、资源目录结构

| 目录名称  | 目录内容               | 父目录    | 其他说明     |
| --------- | ---------------------- | --------- | ------------ |
| Resources | 存放动态加载需要的资源 |           | Assets根目录 |
| Prefabs   | 预制体存放路径         | Resources | ---          |
| Scenes    | 场景存放场景           | Assets    | ---          |
| Scripts   | 存放脚本               | Assets    | ---          |



3、界面对象结构拆分

| 结构        | 结构对象说明                   | 父界面对象 | 其他说明 |      |      |
| ----------- | ------------------------------ | ---------- | -------- | ---- | ---- |
| SampleScene | 主场景                         |            |          |      |      |
| Main        | 游戏界面父物体，管理者脚本挂载 |            |          |      |      |
| ParentObj   | 主界面父父物体                 | Game       |          |      |      |
| StartBtn    | 启动按钮                       |            |          |      |      |



4、脚本功能部分

| 类             | 主要职责             | 其他说明Main                     |
| -------------- | -------------------- | -------------------------------- |
| GameController | 用于启动游戏         | 持有敌我模型引用信息，初始化数据 |
| UIRewardModel  | 奖励数据类           | 用来初始化数据                   |
| MainView       | 主界面UI类           | 处理主界面UI展示信息             |
| ItemPanelView  | 格子信息数据类       | 用于管理格子item的UI逻辑         |
| Const          | 管理常量数据         | 无                               |
| Tools          | 公用类，通用功能封装 | 无                               |



5、数据处理

- GameController启动，UIRewardModel初始化数据，缓存给界面使用

  

6、部分功能的实现思想

- 启动器初始化（模拟数据），数据赋值成功后，打开界面
- 拿到数据后进行界面的刷新赋值
- 通过委托事件的方式进行ui界面的刷新

7、关键代码逻辑的流程图

![Image](https://github.com/89trillion-songjunbo/89Test05/blob/master/Assets/89Test05%20脚本流程图.png)


8、游戏运行流程图
![Image](https://github.com/89trillion-songjunbo/89Test05/blob/master/89Test05.png)
