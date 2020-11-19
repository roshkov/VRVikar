using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCarController : MonoBehaviour
{
    
    
    public float driveSpeed;
    public Rigidbody rb;

    void Start()
    {
        // rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate () {
      
        
        // Go forward
        if (Input.GetKey(KeyCode.W))
        {
                rb.AddForce(transform.forward * driveSpeed* 10);
        }

        if (Input.GetKey(KeyCode.S))
        {
                rb.AddForce(Vector3.back * driveSpeed * 10);
        }


    }


}
