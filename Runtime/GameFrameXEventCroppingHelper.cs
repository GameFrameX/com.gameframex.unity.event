using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Event.Runtime
{
    [Preserve]
    public class GameFrameXEventCroppingHelper : MonoBehaviour
    {
        private Type[] m_Types;

        [Preserve]
        private void Start()
        {
            m_Types = new Type[]
            {
                typeof(EventManager),
                typeof(EventComponent),
                typeof(GameEventArgs),
                typeof(IEventManager),
            };
        }
    }
}