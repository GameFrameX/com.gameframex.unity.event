<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Event ゲームイベントシステムコンポーネント

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · [QQグループ](https://qm.qq.com/q/5kbDVBdUeS)

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>
## 概要

文字列 ID ベースのイベントバス。スレッドセーフな遅延ディスパッチ（`Fire` — 次フレームでメインスレッド呼び出し）と即時ディスパッチ（`FireNow`）をサポートし、未購読イベントのデフォルトハンドラを設定できます。

### 機能

- 文字列 ID によるイベントのサブスクライブ / サブスクライブ解除
- `Fire` — スレッドセーフな遅延ディスパッチ（次フレーム、メインスレッド）
- `FireNow` — 即時同期ディスパッチ
- `Fire(sender, eventId)` — カスタムイベント引数不要のショートカット
- `Check` / `CheckSubscribe` — 存在確認または未登録時の自動サブスクライブ
- `Count` / `EventHandlerCount` / `EventCount` — ハンドラ統計
- 未購読イベントのデフォルトハンドラフォールバック

## クイックスタート

### インストール方法（いずれかを選択）

1. Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：
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

   `scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

2. `manifest.json` の `dependencies` に以下を追加：
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/gameframex/com.gameframex.unity.event.git"
   }
   ```
3. Unity の `Packages Manager` で `Git URL` を使用して追加：`https://github.com/gameframex/com.gameframex.unity.event.git`
4. リポジトリを直接ダウンロードして Unity プロジェクトの `Packages` ディレクトリに配置すると、自動的に読み込まれます。

## 使用例

### カスタムイベントの定義

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

### サブスクライブ / サブスクライブ解除

```csharp
eventComponent.Subscribe("level_up", OnLevelUp);
eventComponent.Unsubscribe("level_up", OnLevelUp);

void OnLevelUp(object sender, GameEventArgs e)
{
    var args = (LevelUpEventArgs)e;
    Debug.Log($"レベル {args.Level} にアップ");
}
```

### 確認 / 確認してサブスクライブ

```csharp
// サブスクライブ済みか確認
bool exists = eventComponent.Check("level_up", OnLevelUp);

// 未登録の場合のみサブスクライブ
eventComponent.CheckSubscribe("level_up", OnLevelUp);
```

### イベントの発火

遅延モード（スレッドセーフ、次フレームでメインスレッド呼び出し）：

```csharp
eventComponent.Fire(this, LevelUpEventArgs.Create(5));
```

即時モード（すぐにディスパッチ、メインスレッドのみ）：

```csharp
eventComponent.FireNow(this, LevelUpEventArgs.Create(5));
```

ショートカット（カスタムイベント引数不要）：

```csharp
eventComponent.Fire(this, "level_up");
```

### デフォルトハンドラ

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);

void OnDefaultEvent(object sender, GameEventArgs e)
{
    Debug.Log($"未処理のイベント: {e.Id}");
}
```

### 統計情報

```csharp
int totalHandlers = eventComponent.EventHandlerCount;
int totalEvents = eventComponent.EventCount;
int handlersForEvent = eventComponent.Count("level_up");
```

## ドキュメントとリソース

- [ドキュメント](https://gameframex.doc.alianblank.com)

## コミュニティとサポート

- [QQグループ](https://qm.qq.com/q/5kbDVBdUeS)

## 変更履歴

変更履歴は [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases) をご覧ください。

## ライセンス

このプロジェクトは [Apache License 2.0](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE) の下で公開されています。
