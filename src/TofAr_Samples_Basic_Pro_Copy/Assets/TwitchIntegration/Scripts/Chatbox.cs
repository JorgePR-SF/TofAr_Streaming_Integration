using System.Collections;
using System.Collections.Generic;
using System.Text;
using Lexone.UnityTwitchChat;
using UnityEngine;
using UnityEngine.UI;

namespace SystemFriend.TwitchIntegration
{
    public class Chatbox : MonoBehaviour
    {
        public IRC twitchIRC = null;
        public GameObject contentBox;
        public GameObject messagePrefab;
        public int limitOfMessagesSaved = 50;

        private Queue<GameObject> savedMessages = new Queue<GameObject>();
        private ScrollRect scrollRect;

        private void Awake()
        {
            twitchIRC.OnChatMessage += OnNewTwitchMessage;
            scrollRect = GetComponent<ScrollRect>();
        }

        private void OnDisable()
        {
            twitchIRC.OnChatMessage -= OnNewTwitchMessage;
        }

        private void Update()
        {

            scrollRect.normalizedPosition = new Vector2(0, 0);
        }

        private void OnNewTwitchMessage(Chatter chatter)
        {
            if (savedMessages.Count > limitOfMessagesSaved)
            {
                Destroy(savedMessages.Dequeue());
            }
            Debug.Log(chatter.tags.colorHex);
            
            StringBuilder sb = new StringBuilder();

            sb.Append("<color=" + chatter.tags.colorHex + ">");
            sb.Append(chatter.tags.displayName);
            sb.Append("</color>");
            sb.Append(": ");
            sb.Append(chatter.message);

            string messageContent = sb.ToString();

            var newMsg = Instantiate(messagePrefab, contentBox.transform);

            newMsg.GetComponent<Text>().text = messageContent;
            scrollRect.normalizedPosition = new Vector2(0, 0);

            savedMessages.Enqueue(newMsg);
        }
    }
}
