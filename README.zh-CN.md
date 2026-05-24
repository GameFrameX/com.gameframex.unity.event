<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160"/>

# Game Frame X Event 游戏事件系统组件

[![License](https://img.shields.io/github/license/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE)
[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/releases)
[![Documentation](https://img.shields.io/badge/Documentation-文档-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · [QQ群](https://qm.qq.com/q/5kbDVBdUeS) · **语言**

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

---

## 项目简介

**Event 游戏事件系统组件 (Event Component)** - 提供游戏事件系统的组件相关的接口，管理游戏事件的订阅与派发。

### 功能

- **事件订阅与取消订阅：** 允许根据事件ID来订阅或取消订阅事件处理回调函数。
- **事件派发：** 提供线程安全的事件派发方法 `Fire`，即使在非主线程也能保证在主线程回调事件处理函数，以及立即派发的方法 `FireNow`。
- **处理函数统计：** 可以获取当前已订阅的事件处理函数数量和事件数量。
- **默认事件处理函数设置：** 允许设置默认事件处理函数来捕获未明确订阅的事件。

## 快速开始

### 安装方式（任选其一）

1. 直接在 `manifest.json` 的 `dependencies` 节点下添加以下内容：
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/AlianBlank/com.gameframex.unity.event.git"
   }
   ```
2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加库，地址为：`https://github.com/AlianBlank/com.gameframex.unity.event.git`
3. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。

## 使用示例

### 获取事件数量和处理函数数量

```csharp
int eventHandlerCount = eventComponent.EventHandlerCount;
int eventCount = eventComponent.EventCount;
```

### 订阅事件

```csharp
eventComponent.Subscribe("game_start", OnGameStart);
```

其中 `OnGameStart` 是遵循 `EventHandler<GameEventArgs>` 委托的方法。

### 取消订阅事件

```csharp
eventComponent.Unsubscribe("game_start", OnGameStart);
```

### 抛出事件

线程安全方式（下一帧分发）：

```csharp
eventComponent.Fire(this, new GameEventArgs());
```

立即模式（立刻分发）：

```csharp
eventComponent.FireNow(this, new GameEventArgs());
```

### 设置默认事件处理函数

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);
```

其中 `OnDefaultEvent` 是遵循 `EventHandler<GameEventArgs>` 委托的方法。

## 文档与资源

- [文档](https://gameframex.doc.alianblank.com)

## 社区与支持

- [QQ群](https://qm.qq.com/q/5kbDVBdUeS)

## 更新日志

查看 [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases) 了解更新日志。

## 开源协议

本项目基于 [MIT 协议](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE) 开源。
