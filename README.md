## HOMEPAGE

GameFrameX 的 Event 游戏事件系统的组件

**Event 游戏事件系统的组件 (Event Component)** - 提供游戏事件系统的组件相关的接口。

# 使用文档(文档编写于GPT4)

EventComponent 类是一个游戏事件系统的组件，用于管理游戏事件的订阅与派发。

## 功能

- **事件订阅与取消订阅：** 允许你根据事件ID来订阅或取消订阅事件处理回调函数。
- **事件派发：** 提供了线程安全的事件派发方法 `Fire`，即使在非主线程也能保证在主线程回调事件处理函数，以及立即派发的方法 `FireNow`。
- **处理函数统计：** 可以获取当前已订阅的事件处理函数数量和事件数量。
- **默认事件处理函数设置：** 允许设置默认事件处理函数来捕获未明确订阅的事件。

## 使用方法

1. **获取事件数量和事件处理函数的数量：**

   ```csharp
   int eventHandlerCount = eventComponent.EventHandlerCount;
   int eventCount = eventComponent.EventCount;
   ```

2. **订阅事件：**

   ```csharp
   eventComponent.Subscribe("game_start", OnGameStart);
   ```

   其中 `OnGameStart` 是遵循 `EventHandler<GameEventArgs>` 委托的方法。

3. **取消订阅事件：**

   ```csharp
   eventComponent.Unsubscribe("game_start", OnGameStart);
   ```

4. **抛出事件：**

    - 线程安全的方式（在下一帧分发）:

      ```csharp
      eventComponent.Fire(this, new GameEventArgs());
      ```

    - 立即模式（立刻分发）:

      ```csharp
      eventComponent.FireNow(this, new GameEventArgs());
      ```

5. **设置默认事件处理函数：**

   ```csharp
   eventComponent.SetDefaultHandler(OnDefaultEvent);
   ```

   其中 `OnDefaultEvent` 是遵循 `EventHandler<GameEventArgs>` 委托的方法。

通过上述步骤，可以在游戏中有效地使用事件组件进行事件的订阅、取消订阅和派发，从而实现游戏中的事件驱动编程。

# 使用方式(任选其一)

1. 直接在 `manifest.json` 的文件中的 `dependencies` 节点下添加以下内容
   ```json
      {"com.gameframex.unity.event": "https://github.com/AlianBlank/com.gameframex.unity.event.git"}
    ```
2. 在Unity 的`Packages Manager` 中使用`Git URL` 的方式添加库,地址为：https://github.com/AlianBlank/com.gameframex.unity.event.git

3. 直接下载仓库放置到Unity 项目的`Packages` 目录下。会自动加载识别