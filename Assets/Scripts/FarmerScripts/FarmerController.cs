using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour
{
    private float horizontalInput;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float xRange;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
        xRange = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the player's input and move the player according to input * speed over time
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //restrict the player's max input to an xRange within game view
        //future modification use the camera size to create bounds that the player cannot cross?
        if(Mathf.Abs(transform.position.x) > xRange)
        {
            if (transform.position.x > 0)
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        //throw a projectile using the space key
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Launch the projectile
            Instantiate(projectilePrefab, new Vector3(transform.position.x, projectilePrefab.transform.position.y, transform.position.z), projectilePrefab.transform.rotation);
        }
    }
}
