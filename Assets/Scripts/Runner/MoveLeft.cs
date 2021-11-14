using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15;
    private float leftBound = -15;

    private RunnerController runner;

    private void Start()
    {
        runner = GameObject.Find("Player").GetComponent<RunnerController>();
    }
    void Update()
    {
        if(runner.gameOver == false)
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
