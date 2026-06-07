<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Event

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>
## Overview

Type-identified event bus for Unity. Subscribe handlers by string ID, dispatch thread-safely from any thread (`Fire` — next frame on main thread) or immediately (`FireNow`), and set a default handler for unhandled events.

### Features

- Subscribe / unsubscribe by string event ID
- `Fire` — thread-safe deferred dispatch (next frame, main thread)
- `FireNow` — immediate synchronous dispatch
- `Fire(sender, eventId)` — shorthand without custom event args
- `Check` / `CheckSubscribe` — check existence or subscribe-if-absent
- `Count` / `EventHandlerCount` / `EventCount` — handler statistics
- Default handler fallback for unhandled events

## Quick Start

### Installation

Choose one of the following methods:

1. Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:
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

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

2. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/gameframex/com.gameframex.unity.event.git"
   }
   ```
3. Use **Packages Manager** in Unity with **Git URL**: `https://github.com/gameframex/com.gameframex.unity.event.git`
4. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.

## Usage

### Define a Custom Event

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

### Subscribe / Unsubscribe

```csharp
eventComponent.Subscribe("level_up", OnLevelUp);
eventComponent.Unsubscribe("level_up", OnLevelUp);

void OnLevelUp(object sender, GameEventArgs e)
{
    var args = (LevelUpEventArgs)e;
    Debug.Log($"Level up to {args.Level}");
}
```

### Check / CheckSubscribe

```csharp
// Check if a handler is already subscribed
bool exists = eventComponent.Check("level_up", OnLevelUp);

// Subscribe only if not already subscribed
eventComponent.CheckSubscribe("level_up", OnLevelUp);
```

### Fire an Event

Deferred (thread-safe, dispatched next frame on main thread):

```csharp
eventComponent.Fire(this, LevelUpEventArgs.Create(5));
```

Immediate (dispatched right away, main thread only):

```csharp
eventComponent.FireNow(this, LevelUpEventArgs.Create(5));
```

Shorthand without custom event args:

```csharp
eventComponent.Fire(this, "level_up");
```

### Default Handler

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);

void OnDefaultEvent(object sender, GameEventArgs e)
{
    Debug.Log($"Unhandled event: {e.Id}");
}
```

### Statistics

```csharp
int totalHandlers = eventComponent.EventHandlerCount;
int totalEvents = eventComponent.EventCount;
int handlersForEvent = eventComponent.Count("level_up");
```

## Documentation

- [Documentation](https://gameframex.doc.alianblank.com)

## Community

- QQ Group: 467608841 / 233840761

## Changelog

See [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases) for changelog.

## License

This project is licensed under the [Apache License 2.0](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE).
