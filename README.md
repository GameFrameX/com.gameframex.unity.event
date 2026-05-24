<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160"/>

# Game Frame X Event Component

[![License](https://img.shields.io/github/license/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE)
[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/releases)
[![Documentation](https://img.shields.io/badge/Documentation-Documentation-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · [QQ Group](https://qm.qq.com/q/5kbDVBdUeS) · **Language**

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

---

## Project Overview

The **Event Component** provides interfaces for a game event system, managing event subscription and dispatch.

### Features

- **Event Subscription and Unsubscription:** Subscribe or unsubscribe event handler callbacks by event ID.
- **Event Dispatch:** Thread-safe dispatch method `Fire` (guaranteed to invoke on the main thread) and immediate dispatch method `FireNow`.
- **Handler Statistics:** Get the current count of subscribed event handlers and events.
- **Default Handler:** Set a default event handler to capture events that are not explicitly subscribed.

## Quick Start

### Installation

Choose one of the following methods:

1. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/AlianBlank/com.gameframex.unity.event.git"
   }
   ```
2. Use **Packages Manager** in Unity with **Git URL**: `https://github.com/AlianBlank/com.gameframex.unity.event.git`
3. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.

## Usage Examples

### Get Event and Handler Count

```csharp
int eventHandlerCount = eventComponent.EventHandlerCount;
int eventCount = eventComponent.EventCount;
```

### Subscribe to an Event

```csharp
eventComponent.Subscribe("game_start", OnGameStart);
```

Where `OnGameStart` is a method following the `EventHandler<GameEventArgs>` delegate.

### Unsubscribe from an Event

```csharp
eventComponent.Unsubscribe("game_start", OnGameStart);
```

### Fire an Event

Thread-safe (dispatched next frame):

```csharp
eventComponent.Fire(this, new GameEventArgs());
```

Immediate (dispatched immediately):

```csharp
eventComponent.FireNow(this, new GameEventArgs());
```

### Set Default Handler

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);
```

Where `OnDefaultEvent` is a method following the `EventHandler<GameEventArgs>` delegate.

## Documentation & Resources

- [Documentation](https://gameframex.doc.alianblank.com)

## Community & Support

- [QQ Group](https://qm.qq.com/q/5kbDVBdUeS)

## Changelog

See [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases) for changelog.

## License

This project is licensed under the [MIT License](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE).
