<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160"/>

# Game Frame X Event 遊戲事件系統組件

[![License](https://img.shields.io/github/license/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE)
[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/releases)
[![Documentation](https://img.shields.io/badge/Documentation-文檔-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · [QQ群](https://qm.qq.com/q/5kbDVBdUeS) · **語言**

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

---

## 項目簡介

**Event 遊戲事件系統組件 (Event Component)** - 提供遊戲事件系統組件相關的介面，管理遊戲事件的訂閱與派發。

### 功能

- **事件訂閱與取消訂閱：** 允許根據事件ID來訂閱或取消訂閱事件處理回呼函數。
- **事件派發：** 提供執行緒安全的事件派發方法 `Fire`，即使在非主執行緒也能保證在主執行緒回呼事件處理函數，以及立即派發的方法 `FireNow`。
- **處理函數統計：** 可以取得目前已訂閱的事件處理函數數量和事件數量。
- **預設事件處理函數設定：** 允許設定預設事件處理函數來捕獲未明確訂閱的事件。

## 快速開始

### 安裝方式（任選其一）

1. 直接在 `manifest.json` 的 `dependencies` 節點下新增以下內容：
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/AlianBlank/com.gameframex.unity.event.git"
   }
   ```
2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式新增庫，地址為：`https://github.com/AlianBlank/com.gameframex.unity.event.git`
3. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

## 使用範例

### 取得事件數量和處理函數數量

```csharp
int eventHandlerCount = eventComponent.EventHandlerCount;
int eventCount = eventComponent.EventCount;
```

### 訂閱事件

```csharp
eventComponent.Subscribe("game_start", OnGameStart);
```

其中 `OnGameStart` 是遵循 `EventHandler<GameEventArgs>` 委託的方法。

### 取消訂閱事件

```csharp
eventComponent.Unsubscribe("game_start", OnGameStart);
```

### 派發事件

執行緒安全方式（下一幀派發）：

```csharp
eventComponent.Fire(this, new GameEventArgs());
```

立即模式（立刻派發）：

```csharp
eventComponent.FireNow(this, new GameEventArgs());
```

### 設定預設事件處理函數

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);
```

其中 `OnDefaultEvent` 是遵循 `EventHandler<GameEventArgs>` 委託的方法。

## 文檔與資源

- [文檔](https://gameframex.doc.alianblank.com)

## 社區與支援

- [QQ群](https://qm.qq.com/q/5kbDVBdUeS)

## 更新日誌

查看 [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases) 了解更新日誌。

## 開源協議

本專案基於 [MIT 協議](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE) 開源。
