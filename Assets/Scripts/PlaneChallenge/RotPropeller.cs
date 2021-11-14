using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotPropeller : MonoBehaviour
{
    private void Update()
    {
        this.transform.RotateAround(transform.position, Vector3.forward, 1000 * Time.deltaTime);
    }
}
