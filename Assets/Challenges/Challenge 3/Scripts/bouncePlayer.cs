using UnityEngine;

public class bouncePlayer : MonoBehaviour
{
    Rigidbody playerRb;
    Vector3 add_force;

    private float pushUp = 5.0f;
    private void Start()
    {
        add_force = new Vector3(0, pushUp, 0);
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerRb.AddForce(add_force, ForceMode.Impulse);
        }
    }
}
