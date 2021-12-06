using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    private void Rotate()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, input * rotationSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Rotate();
    }
}
