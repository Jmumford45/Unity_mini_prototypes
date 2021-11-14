using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Camera cam_ref;
    [SerializeField]
    private Vector3 offset;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        cam_ref = Camera.main;
        offset = cam_ref.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}


