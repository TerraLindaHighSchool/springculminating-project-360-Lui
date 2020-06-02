using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private float zDestroy = -20.0f;
    private Rigidbody objectRb;
    private GameObject planeG;
    private GameObject planeG1;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        planeG = GameObject.Find("PlaneG");
        planeG1 = GameObject.Find("PlaneG1");
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);

        if(transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }

        planeG.transform.Translate(Vector3.back * Time.deltaTime * (speed / 5));
        planeG1.transform.Translate(Vector3.back * Time.deltaTime * (speed / 5));
    }
}
