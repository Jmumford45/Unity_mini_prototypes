using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody enemyRb { get; private set; }    
    private GameObject player;

    private float destroyPos = 10.0f;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 lookDir = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDir * speed);

        if (this.transform.position.y < -destroyPos)
            Destroy(this.gameObject);
    }
}

//In Enemy.cs, destroy the enemies if their position is less than a -Y value
