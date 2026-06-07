<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Event 遊戲事件系統組件

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 概述

基於字串 ID 的事件匯流排。支援執行緒安全的延遲分發（`Fire` — 下一幀主執行緒回呼）和立即分發（`FireNow`），可設定預設處理器兜底未訂閱事件。

### 功能

- 基於字串 ID 的事件訂閱 / 取消訂閱
- `Fire` — 執行緒安全的延遲分發（下一幀主執行緒回呼）
- `FireNow` — 立即同步分發
- `Fire(sender, eventId)` — 無需自訂事件參數的快捷方式
- `Check` / `CheckSubscribe` — 檢查存在性或不存在時自動訂閱
- `Count` / `EventHandlerCount` / `EventCount` — 處理函數統計
- 預設處理器兜底未訂閱事件

## 快速開始

### 安裝方式（任選其一）

1. 編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：
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

   `scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

2. 直接在 `manifest.json` 的 `dependencies` 節點下新增以下內容：
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/gameframex/com.gameframex.unity.event.git"
   }
   ```
3. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式新增庫，地址為：`https://github.com/gameframex/com.gameframex.unity.event.git`
4. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

## 使用範例

### 定義自訂事件

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

### 訂閱 / 取消訂閱

```csharp
eventComponent.Subscribe("level_up", OnLevelUp);
eventComponent.Unsubscribe("level_up", OnLevelUp);

void OnLevelUp(object sender, GameEventArgs e)
{
    var args = (LevelUpEventArgs)e;
    Debug.Log($"升級到 {args.Level} 級");
}
```

### 檢查 / 檢查並訂閱

```csharp
// 檢查是否已訂閱
bool exists = eventComponent.Check("level_up", OnLevelUp);

// 不存在時自動訂閱
eventComponent.CheckSubscribe("level_up", OnLevelUp);
```

### 派發事件

延遲模式（執行緒安全，下一幀主執行緒回呼）：

```csharp
eventComponent.Fire(this, LevelUpEventArgs.Create(5));
```

立即模式（立刻分發，僅限主執行緒）：

```csharp
eventComponent.FireNow(this, LevelUpEventArgs.Create(5));
```

快捷方式（無需自訂事件參數）：

```csharp
eventComponent.Fire(this, "level_up");
```

### 預設處理器

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);

void OnDefaultEvent(object sender, GameEventArgs e)
{
    Debug.Log($"未處理的事件: {e.Id}");
}
```

### 統計資訊

```csharp
int totalHandlers = eventComponent.EventHandlerCount;
int totalEvents = eventComponent.EventCount;
int handlersForEvent = eventComponent.Count("level_up");
```

## 文檔與資源

- [文檔](https://gameframex.doc.alianblank.com)

## 社區與支援

- QQ群: 467608841 / 233840761

## 更新日誌

查看 [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases) 了解更新日誌。

## 開源協議

本專案基於 [Apache License 2.0 協議](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE) 開源。
