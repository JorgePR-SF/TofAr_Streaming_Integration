using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SystemFriend.TwitchIntegration
{
    public abstract class Command : ScriptableObject
    {
        [SerializeField] public string commandString;

        public abstract void TriggerAction<T>(T arg);

        public abstract void TriggerAction();
    }
}
