using UnityEngine;

namespace GameFrameX.Event.Runtime
{
    public class GameFrameXEventCroppingHelper : MonoBehaviour
    {
        private void Start()
        {
            _ = typeof(EventManager);
            _ = typeof(EventComponent);
            _ = typeof(GameEventArgs);
            _ = typeof(IEventManager);
        }
    }
}