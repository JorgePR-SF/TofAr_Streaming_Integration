using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public float despawnTime;

    private float timeLeftToDespawn;
    private bool isDespawnable = true;

    private void Start()
    {
        if(despawnTime == 0.0f)
        {
            isDespawnable = false;
        }
        timeLeftToDespawn = despawnTime;
    }

    private void Update()
    {
        CheckTimer();
    }

    private void CheckTimer()
    {
        if(isDespawnable)
        {
            timeLeftToDespawn -= Time.deltaTime;
            if(timeLeftToDespawn <= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
