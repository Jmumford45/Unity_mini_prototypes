
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject focalPoint;

    private bool hasPowerUp;
    private float powerUpStr = 10.0f;
    public float speed;

    private Vector3 indicatorOffset;
    public GameObject powerupIndicator;

    private void MoveForward()
    {
        float vertical_input = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * vertical_input * speed);
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal_Point");
        speed = 5.0f;
        hasPowerUp = false;

        indicatorOffset = new Vector3(0, -0.35f, 0);
    }

    private void Update()
    {
        MoveForward();
        powerupIndicator.transform.position = this.transform.position + indicatorOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerUpStr, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.tag + " with the power up set to " + hasPowerUp);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.SetActive(false);
    }
}
