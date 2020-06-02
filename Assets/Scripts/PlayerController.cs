using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 50.0f;
    private Rigidbody playerRb;
    private float xBound = 10.0f;
    private float zBound = 10.0f;
    private float zBoundB = 12.0f;
    public SpawnManager healthValue;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        healthValue = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(playerRb.transform.forward * verticalInput * speed);
        playerRb.AddForce(playerRb.transform.right * horizontalInput * speed);

        while (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerRb.transform.Rotate(0.0f, 0.0f, 10.0f);
        }
        
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.z < -zBoundB)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundB);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); //Destroys enemy object
            healthValue.health--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
