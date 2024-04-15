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
            throw new System.NotImplementedException();
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
