using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(24, 0, 0);

    private float startDelay = 2f;
    private float repeatRate = 1.5f;

    private RunnerController runner;

    private void Start()
    {
        runner = GameObject.Find("Player").GetComponent<RunnerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        if(runner.gameOver == false)
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }
}
