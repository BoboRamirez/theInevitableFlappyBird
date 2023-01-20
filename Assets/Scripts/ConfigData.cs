using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigData
{
    /// <summary>
    /// world location of bird spawning
    /// </summary>
    public static Vector3 birdPos = new Vector3(-4f, 0.5f);
    /// <summary>
    /// world location of pipe spawner spawning
    /// </summary>
    public static Vector3 pipeSpawnerPos = new Vector3(11f, 0f);

    public static float pipeSpawnDelay = 4f;

    public static float pipeMoveSpeed = 2f;
    
}
