using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SystemFriend.TwitchIntegration
{
    [CreateAssetMenu(fileName = "CommandSpawn", menuName = "SystemFriend/Twitch/CommandSpawn")]
    public class CommandSpawn : Command
    {
        public GameObject spawnableObject;
        public Vector3 spawnPosition;
        public float randomSpawnRadius;

        public override void TriggerAction<T>(T arg)
        {
            switch (arg)
            {
                case Color color:
                    GameObject go = Instantiate(spawnableObject, CalculateRandomPosition(), Quaternion.identity);
                    go.GetComponent<Renderer>().material.color = color;
                    break;

                default:
                    break;
            }
        }

        public override void TriggerAction()
        {
            Instantiate(spawnableObject, CalculateRandomPosition(), Quaternion.identity);
        }

        private Vector3 CalculateRandomPosition()
        {
            Vector3 result = spawnPosition;

            if (randomSpawnRadius <= 0)
            {
                return result;
            }

            result += Random.insideUnitSphere * randomSpawnRadius;

            return result;
        }
    }

}
