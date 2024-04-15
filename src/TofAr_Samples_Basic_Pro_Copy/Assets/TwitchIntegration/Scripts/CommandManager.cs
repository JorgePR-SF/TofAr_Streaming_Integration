
using System;
using System.Collections;
using System.Collections.Generic;
using Lexone.UnityTwitchChat;
using UnityEngine;

namespace SystemFriend.TwitchIntegration
{
    public class CommandManager : MonoBehaviour
    {
        public IRC twitchIRC = null;
        public List<Command> listOfCommands = new List<Command>();

        private void Awake()
        {
            twitchIRC.OnChatMessage += OnNewTwitchMessage;
        }

        private void OnDisable()
        {
            twitchIRC.OnChatMessage -= OnNewTwitchMessage;
        }

        private void OnNewTwitchMessage(Chatter chatter)
        {
            string[] splittedMessage = chatter.message.Split(" ");

            CheckCommands(splittedMessage[0]);
        }

        private void CheckCommands(string text)
        {
            foreach (var command in listOfCommands)
            {
                if (text == command.commandString || command.commandString == "testing")
                {
                    command.TriggerAction();
                }
            }
        }
    }

}
