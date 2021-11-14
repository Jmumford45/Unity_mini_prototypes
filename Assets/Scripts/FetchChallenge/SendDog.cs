using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDog : MonoBehaviour
{
    public GameObject dogPrefab;
    private float time  = 2.0f;
    private float timer;

    private void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = 0;
            }
        }
    }
}
