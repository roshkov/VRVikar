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


    // void FixedUpdate () {
      
        
    //     // Go forward
    //     if (Input.GetKey(KeyCode.W))
    //     {
    //         Debug.Log ("W");
    //             // rb.AddForce(transform.forward * driveSpeed* 10);
    //                 rb.velocity = Vector3.forward * driveSpeed * 10;
    //             // rb.angularVelocity = Vector3.zero;
    //     }

    //     if (Input.GetKey(KeyCode.S))
            
    //     {
    //           Debug.Log ("S");
    //             // rb.AddForce(Vector3.back * driveSpeed * 10);
    //              rb.velocity = Vector3.back * driveSpeed * 10;
    //     }


    // }

    void Update()
    {
          if (Input.GetKey(KeyCode.W))
        {
        transform.Translate(Vector3.forward * Time.deltaTime );
        }

          if (Input.GetKey(KeyCode.S))
            
        {
              Debug.Log ("S");
               transform.Translate(Vector3.back * Time.deltaTime );
        }
      
    }


}
