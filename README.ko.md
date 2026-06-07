<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Event 게임 이벤트 시스템 컴포넌트

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.event)](https://github.com/GameFrameX/com.gameframex.unity.event/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · QQ 그룹: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

## 프로젝트 개요

문자열 ID 기반 이벤트 버스. 스레드 안전한 지연 디스패치(`Fire` — 다음 프레임 메인 스레드 콜백)와 즉시 디스패치(`FireNow`)를 지원하며, 구독되지 않은 이벤트에 대한 기본 핸들러를 설정할 수 있습니다.

### 기능

- 문자열 ID 기반 이벤트 구독 / 구독 해제
- `Fire` — 스레드 안전한 지연 디스패치 (다음 프레임, 메인 스레드)
- `FireNow` — 즉시 동기 디스패치
- `Fire(sender, eventId)` — 커스텀 이벤트 인수 없이 사용하는 단축 방식
- `Check` / `CheckSubscribe` — 존재 확인 또는 미등록 시 자동 구독
- `Count` / `EventHandlerCount` / `EventCount` — 핸들러 통계
- 구독되지 않은 이벤트에 대한 기본 핸들러 폴백

## 빠른 시작

### 설치

다음 방법 중 하나를 선택하세요:

1. Unity 프로젝트의 `Packages/manifest.json`을 편집하여 `scopedRegistries` 섹션을 추가하세요:
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
       "com.gameframex.unity.event": "1.1.2"
     }
   }
   ```

   `scopes`는 이 레지스트리를 통해 어떤 패키지를 해석할지 제어합니다. `com.gameframex`로 시작하는 패키지만 이 레지스트리에서 가져옵니다.

2. `manifest.json`의 `dependencies`에 직접 추가:
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/gameframex/com.gameframex.unity.event.git"
   }
   ```
3. Unity의 **Package Manager**에서 **Git URL**을 사용하여 추가: `https://github.com/gameframex/com.gameframex.unity.event.git`
4. 리포지토리를 Unity 프로젝트의 `Packages` 디렉토리에 클론하세요. 자동으로 로드됩니다.

### 설치 방법 (선택)

1. Unity 프로젝트의 `Packages/manifest.json`을 편집하여 `scopedRegistries` 섹션을 추가하세요:
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

   `scopes`는 이 레지스트리를 통해 어떤 패키지를 해석할지 제어합니다. `com.gameframex`로 시작하는 패키지만 이 레지스트리에서 가져옵니다.

2. `manifest.json`의 `dependencies`에 다음 내용을 추가:
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/gameframex/com.gameframex.unity.event.git"
   }
   ```
3. Unity의 `Packages Manager`에서 `Git URL`을 사용하여 추가: `https://github.com/gameframex/com.gameframex.unity.event.git`
4. 저장소를 직접 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치하면 자동으로 로드됩니다.

## 사용 예시

### 커스텀 이벤트 정의

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

### 구독 / 구독 해제

```csharp
eventComponent.Subscribe("level_up", OnLevelUp);
eventComponent.Unsubscribe("level_up", OnLevelUp);

void OnLevelUp(object sender, GameEventArgs e)
{
    var args = (LevelUpEventArgs)e;
    Debug.Log($"레벨 {args.Level}(으)로 업");
}
```

### 확인 / 확인 후 구독

```csharp
// 이미 구독되어 있는지 확인
bool exists = eventComponent.Check("level_up", OnLevelUp);

// 미등록 시에만 구독
eventComponent.CheckSubscribe("level_up", OnLevelUp);
```

### 이벤트 발생

지연 모드 (스레드 안전, 다음 프레임 메인 스레드 콜백):

```csharp
eventComponent.Fire(this, LevelUpEventArgs.Create(5));
```

즉시 모드 (즉시 디스패치, 메인 스레드 전용):

```csharp
eventComponent.FireNow(this, LevelUpEventArgs.Create(5));
```

단축 방식 (커스텀 이벤트 인수 없이):

```csharp
eventComponent.Fire(this, "level_up");
```

### 기본 핸들러

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);

void OnDefaultEvent(object sender, GameEventArgs e)
{
    Debug.Log($"처리되지 않은 이벤트: {e.Id}");
}
```

### 통계

```csharp
int totalHandlers = eventComponent.EventHandlerCount;
int totalEvents = eventComponent.EventCount;
int handlersForEvent = eventComponent.Count("level_up");
```

## 문서 및 자료

- [문서](https://gameframex.doc.alianblank.com)

## 커뮤니티 및 지원

- QQ 그룹: 467608841 / 233840761

## 변경 로그

변경 로그는 [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases)에서 확인하세요.


## 의존성

| 패키지 | 설명 |
|--------|------|
| (无) | - |

## 라이선스

자세한 내용은 [LICENSE.md](LICENSE.md) 파일을 참조하세요.
