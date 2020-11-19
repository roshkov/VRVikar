using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovementController : MonoBehaviour
{

    public Transform topOfLever;
    public Rigidbody vehicle;
    private float tilt;

    // Update is called once per frame
    void Update()
    {
        tilt = topOfLever.rotation.eulerAngles.x;
        if(tilt < 355 && tilt > 290){
            tilt = Mathf.Abs(tilt-360);
        }
        
        vehicle.AddForce(vehicle.transform.forward * tilt / 2, ForceMode.Acceleration);
    }

    private void OnTriggerStay(Collider other){
        if(other.CompareTag("PlayerHand")){
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
