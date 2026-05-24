<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160"/>

# Game Frame X Event ゲームイベントシステムコンポーネント

[![License](https://img.shields.io/github/license/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE)
[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/releases)
[![Documentation](https://img.shields.io/badge/Documentation-ドキュメント-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · [QQグループ](https://qm.qq.com/q/5kbDVBdUeS) · **言語**

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>

---

## プロジェクト概要

**Event ゲームイベントシステムコンポーネント (Event Component)** - ゲームイベントのサブスクライブとディスパッチを管理するインターフェースを提供します。

### 機能

- **イベントのサブスクライブとサブスクライブ解除：** イベントIDに基づいてイベントハンドラコールバックをサブスクライブまたはサブスクライブ解除します。
- **イベントのディスパッチ：** スレッドセーフなディスパッチメソッド `Fire`（メインスレッドで呼び出されることを保証）と即時ディスパッチメソッド `FireNow` を提供します。
- **ハンドラ統計：** サブスクライブ済みのイベントハンドラ数とイベント数を取得します。
- **デフォルトハンドラ：** 明示的にサブスクライブされていないイベントをキャッチするデフォルトイベントハンドラを設定します。

## クイックスタート

### インストール方法（いずれかを選択）

1. `manifest.json` の `dependencies` に以下を追加：
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/AlianBlank/com.gameframex.unity.event.git"
   }
   ```
2. Unity の `Packages Manager` で `Git URL` を使用して追加：`https://github.com/AlianBlank/com.gameframex.unity.event.git`
3. リポジトリを直接ダウンロードして Unity プロジェクトの `Packages` ディレクトリに配置すると、自動的に読み込まれます。

## 使用例

### イベント数とハンドラ数の取得

```csharp
int eventHandlerCount = eventComponent.EventHandlerCount;
int eventCount = eventComponent.EventCount;
```

### イベントのサブスクライブ

```csharp
eventComponent.Subscribe("game_start", OnGameStart);
```

`OnGameStart` は `EventHandler<GameEventArgs>` デリゲートに従うメソッドです。

### イベントのサブスクライブ解除

```csharp
eventComponent.Unsubscribe("game_start", OnGameStart);
```

### イベントの発火

スレッドセーフ（次フレームでディスパッチ）：

```csharp
eventComponent.Fire(this, new GameEventArgs());
```

即時（すぐにディスパッチ）：

```csharp
eventComponent.FireNow(this, new GameEventArgs());
```

### デフォルトハンドラの設定

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);
```

`OnDefaultEvent` は `EventHandler<GameEventArgs>` デリゲートに従うメソッドです。

## ドキュメントとリソース

- [ドキュメント](https://gameframex.doc.alianblank.com)

## コミュニティとサポート

- [QQグループ](https://qm.qq.com/q/5kbDVBdUeS)

## 変更履歴

変更履歴は [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases) をご覧ください。

## ライセンス

このプロジェクトは [MIT ライセンス](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE) の下で公開されています。
