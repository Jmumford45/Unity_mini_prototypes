using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;
    private Camera camRef;

    // Start is called before the first frame update
    void Start()
    {
        camRef = Camera.main;
        offset = camRef.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;

        transform.LookAt(plane.transform);
    }
}
