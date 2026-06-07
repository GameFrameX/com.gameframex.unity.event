<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Event 游戏事件系统组件

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>
## 概述

基于字符串 ID 的事件总线。支持线程安全的延迟分发（`Fire` — 下一帧主线程回调）和立即分发（`FireNow`），可设置默认处理器兜底未订阅事件。

### 功能

- 基于字符串 ID 的事件订阅 / 取消订阅
- `Fire` — 线程安全的延迟分发（下一帧主线程回调）
- `FireNow` — 立即同步分发
- `Fire(sender, eventId)` — 无需自定义事件参数的快捷方式
- `Check` / `CheckSubscribe` — 检查存在性或不存在时自动订阅
- `Count` / `EventHandlerCount` / `EventCount` — 处理函数统计
- 默认处理器兜底未订阅事件

## 快速开始

### 安装方式（任选其一）

1. 编辑 Unity 项目的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：
   ```json
   {
     "scopedRegistries": [
       {
         "name": "GameFrameX",
         "url": "https://gameframex.upm.alianblank.uk",
         "scopes": [
           "com.gameframex"
         ]
       }
     ],
     "dependencies": {
       "com.gameframex.unity.event": "1.1.1"
     }
   }
   ```

   `scopes` 控制哪些包通过此注册表解析。只有以 `com.gameframex` 开头的包才会从这个注册表获取。

2. 直接在 `manifest.json` 的 `dependencies` 节点下添加以下内容：
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/gameframex/com.gameframex.unity.event.git"
   }
   ```
3. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加库，地址为：`https://github.com/gameframex/com.gameframex.unity.event.git`
4. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。

## 使用示例

### 定义自定义事件

```csharp
public class LevelUpEventArgs : GameEventArgs
{
    public override string Id => "level_up";
    public int Level { get; private set; }

    public static LevelUpEventArgs Create(int level)
    {
        var args = ReferencePool.Acquire<LevelUpEventArgs>();
        args.Level = level;
        return args;
    }

    public override void Clear()
    {
        base.Clear();
        Level = 0;
    }
}
```

### 订阅 / 取消订阅

```csharp
eventComponent.Subscribe("level_up", OnLevelUp);
eventComponent.Unsubscribe("level_up", OnLevelUp);

void OnLevelUp(object sender, GameEventArgs e)
{
    var args = (LevelUpEventArgs)e;
    Debug.Log($"升级到 {args.Level} 级");
}
```

### 检查 / 检查并订阅

```csharp
// 检查是否已订阅
bool exists = eventComponent.Check("level_up", OnLevelUp);

// 不存在时自动订阅
eventComponent.CheckSubscribe("level_up", OnLevelUp);
```

### 抛出事件

延迟模式（线程安全，下一帧主线程回调）：

```csharp
eventComponent.Fire(this, LevelUpEventArgs.Create(5));
```

立即模式（立刻分发，仅限主线程）：

```csharp
eventComponent.FireNow(this, LevelUpEventArgs.Create(5));
```

快捷方式（无需自定义事件参数）：

```csharp
eventComponent.Fire(this, "level_up");
```

### 默认处理器

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);

void OnDefaultEvent(object sender, GameEventArgs e)
{
    Debug.Log($"未处理的事件: {e.Id}");
}
```

### 统计信息

```csharp
int totalHandlers = eventComponent.EventHandlerCount;
int totalEvents = eventComponent.EventCount;
int handlersForEvent = eventComponent.Count("level_up");
```

## 文档与资源

- [文档](https://gameframex.doc.alianblank.com)

## 社区与支持

- QQ群: 467608841 / 233840761

## 更新日志

查看 [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases) 了解更新日志。

## 开源协议

本项目基于 [Apache License 2.0 协议](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE) 开源。
