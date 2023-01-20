using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    /// <summary>
    /// the delta time between two pipes' spawning
    /// </summary>
    /// <summary>
    /// the pipe to clone
    /// </summary>
    [SerializeField] private GameObject pipe;
    /// <summary>
    /// time counter of pipe spawning
    /// </summary>
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 0;
        Random.InitState((int)System.DateTime.Now.Ticks);
        Instantiate(pipe, getRandomPipeLocation(2f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime < ConfigData.pipeSpawnDelay / GameManager.Difficulty)
        {
            spawnTime += Time.deltaTime;
        }
        else
        {
            Instantiate(pipe, getRandomPipeLocation(2f), Quaternion.identity);
            spawnTime -= ConfigData.pipeSpawnDelay / GameManager.Difficulty;
        }
    }
    /// <summary>
    /// get random position for pipe to spawn, need further attention to make yMax adapt to screen size
    /// </summary>
    /// <param name="yMax">boundary of y</param>
    /// <returns>position of new pipe</returns>
    static Vector3 getRandomPipeLocation(float yMax)
    {
        return new Vector3(11f, (Random.value - 0.5f) * 2 * yMax);
    }
}
