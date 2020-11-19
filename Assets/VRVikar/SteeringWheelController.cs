using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelController : MonoBehaviour
{
    //RightHand
    public GameObject rightHand;
    private Transform rightHandOriginalParent;
    private bool rightHandOnWheel = false;
    //LeftHand
    public GameObject leftHand;
    private Transform leftHandOriginalParent;
    private bool leftHandOnWheel = false;
    public Transform[] snapPositions;
    //Vehicle
    public GameObject vehicle;
    private Rigidbody rb;
    public float currentWheelRotation = 0;
    //turn damping, higher number reponds more accurately to wheel rotation.
    private float turnDampening = 10;
    public Transform directionalObject;
    
    void Start()
    {
        rb = vehicle.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ReleaseHandsFromWheel();
        ConvertHandRotationToWheelRotation();
        TurnVehicle();

        currentWheelRotation = -transform.rotation.eulerAngles.z;
    }

    private void TurnVehicle(){
        if(rightHandOnWheel || leftHandOnWheel){
            var turn = -transform.rotation.eulerAngles.z;
            if(turn < -350)
                turn = turn + 360;
        
            rb.MoveRotation(Quaternion.RotateTowards(vehicle.transform.rotation, Quaternion.Euler(0,turn,0), Time.deltaTime * turnDampening));
        }
    }

    private void ReleaseHandsFromWheel(){
        if(rightHandOnWheel == true && OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)){
            rightHand.transform.parent = rightHandOriginalParent;
            rightHand.transform.position = rightHandOriginalParent.position;
            rightHand.transform.rotation = rightHandOriginalParent.rotation;
            rightHandOnWheel = false;
        }
        if(leftHandOnWheel == true && OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch)){
            leftHand.transform.parent = leftHandOriginalParent;
            leftHand.transform.position = leftHandOriginalParent.position;
            leftHand.transform.rotation = leftHandOriginalParent.rotation;
            leftHandOnWheel = false;
        }
        if(leftHandOnWheel == false && rightHandOnWheel == false)
            transform.parent = transform.root;
    }

    private void ConvertHandRotationToWheelRotation(){
        if(rightHandOnWheel == true && leftHandOnWheel == false){
            Quaternion newRot = Quaternion.Euler(0,vehicle.transform.rotation.eulerAngles.y,rightHandOriginalParent.transform.rotation.eulerAngles.z);
            directionalObject.rotation = newRot;
            transform.parent = directionalObject;
        }
        else if(rightHandOnWheel == false && leftHandOnWheel == true){
            Quaternion newRot = Quaternion.Euler(0,vehicle.transform.rotation.eulerAngles.y,leftHandOriginalParent.transform.rotation.eulerAngles.z);
            directionalObject.rotation = newRot;
            transform.parent = directionalObject;
        }
        else if(rightHandOnWheel == true && leftHandOnWheel == true){
            Quaternion newRotLeft = Quaternion.Euler(0,vehicle.transform.rotation.eulerAngles.y,leftHandOriginalParent.transform.rotation.eulerAngles.z);
            Quaternion newRotRight = Quaternion.Euler(0,vehicle.transform.rotation.eulerAngles.y,rightHandOriginalParent.transform.rotation.eulerAngles.z);
            Quaternion finalRot = Quaternion.Slerp(newRotLeft, newRotRight, 1.0f/2.0f);
            directionalObject.rotation = finalRot;
            transform.parent = directionalObject;
        }
    }

    private void PlaceHandOnWheel(ref GameObject hand, ref Transform originalParent, ref bool handOnWheel){
        var shortestDistance = Vector3.Distance(snapPositions[0].position, hand.transform.position);
        var bestSnap = snapPositions[0];

        foreach(var snapPosition in snapPositions){
            if(snapPosition.childCount == 0){
                var distance = Vector3.Distance(snapPosition.position, hand.transform.position);
                if(distance < shortestDistance){
                    shortestDistance = distance;
                    bestSnap = snapPosition;
                }
            }
        }

        originalParent = hand.transform.parent;

        hand.transform.parent = bestSnap.transform;
        hand.transform.position = bestSnap.transform.position;

        handOnWheel = true;
    }

    private void OnTriggerStay(Collider other){
        if(other.CompareTag("PlayerHand")){
            if(rightHandOnWheel == false && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
                PlaceHandOnWheel(ref rightHand, ref rightHandOriginalParent, ref rightHandOnWheel);
        }
        if(other.CompareTag("PlayerHand")){
            if(leftHandOnWheel == false && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
                PlaceHandOnWheel(ref leftHand, ref leftHandOriginalParent, ref leftHandOnWheel);
        }
    }
}
