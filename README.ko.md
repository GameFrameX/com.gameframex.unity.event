<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160"/>

# Game Frame X Event 게임 이벤트 시스템 컴포넌트

[![License](https://img.shields.io/github/license/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE)
[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.event)](https://github.com/gameframex/com.gameframex.unity.event/releases)
[![Documentation](https://img.shields.io/badge/Documentation-문서-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · [QQ 그룹](https://qm.qq.com/q/5kbDVBdUeS) · **언어**

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

---

## 프로젝트 개요

**Event 게임 이벤트 시스템 컴포넌트 (Event Component)** - 게임 이벤트 구독 및 디스패치를 관리하는 인터페이스를 제공합니다.

### 기능

- **이벤트 구독 및 구독 해제:** 이벤트 ID를 기반으로 이벤트 핸들러 콜백을 구독하거나 구독 해제합니다.
- **이벤트 디스패치:** 스레드 안전한 디스패치 메서드 `Fire` (메인 스레드에서 콜백 보장)와 즉시 디스패치 메서드 `FireNow`를 제공합니다.
- **핸들러 통계:** 현재 구독된 이벤트 핸들러 수와 이벤트 수를 가져옵니다.
- **기본 핸들러:** 명시적으로 구독되지 않은 이벤트를 캡처하는 기본 이벤트 핸들러를 설정합니다.

## 빠른 시작

### 설치 방법 (선택)

1. `manifest.json`의 `dependencies`에 다음 내용을 추가:
   ```json
   {
      "com.gameframex.unity.event": "https://github.com/AlianBlank/com.gameframex.unity.event.git"
   }
   ```
2. Unity의 `Packages Manager`에서 `Git URL`을 사용하여 추가: `https://github.com/AlianBlank/com.gameframex.unity.event.git`
3. 저장소를 직접 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치하면 자동으로 로드됩니다.

## 사용 예시

### 이벤트 수 및 핸들러 수 가져오기

```csharp
int eventHandlerCount = eventComponent.EventHandlerCount;
int eventCount = eventComponent.EventCount;
```

### 이벤트 구독

```csharp
eventComponent.Subscribe("game_start", OnGameStart);
```

`OnGameStart`는 `EventHandler<GameEventArgs>` 대리자를 따르는 메서드입니다.

### 이벤트 구독 해제

```csharp
eventComponent.Unsubscribe("game_start", OnGameStart);
```

### 이벤트 발생

스레드 안전 (다음 프레임에 디스패치):

```csharp
eventComponent.Fire(this, new GameEventArgs());
```

즉시 (즉시 디스패치):

```csharp
eventComponent.FireNow(this, new GameEventArgs());
```

### 기본 핸들러 설정

```csharp
eventComponent.SetDefaultHandler(OnDefaultEvent);
```

`OnDefaultEvent`는 `EventHandler<GameEventArgs>` 대리자를 따르는 메서드입니다.

## 문서 및 자료

- [문서](https://gameframex.doc.alianblank.com)

## 커뮤니티 및 지원

- [QQ 그룹](https://qm.qq.com/q/5kbDVBdUeS)

## 변경 로그

변경 로그는 [Releases](https://github.com/gameframex/com.gameframex.unity.event/releases)에서 확인하세요.

## 라이선스

이 프로젝트는 [MIT 라이선스](https://github.com/gameframex/com.gameframex.unity.event/blob/main/LICENSE)에 따라 배포됩니다.
