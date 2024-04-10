using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Event.Runtime
{
    [Preserve]
    public class GameFrameXEventCroppingHelper : MonoBehaviour
    {
        [Preserve]
        private void Start()
        {
            _ = typeof(EventManager);
            _ = typeof(EventComponent);
            _ = typeof(GameEventArgs);
            _ = typeof(IEventManager);
        }
    }
}