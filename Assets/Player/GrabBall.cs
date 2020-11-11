using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall : MonoBehaviour
{
    //Stores the trigger on the player that detects the ball
    private SphereCollider ballCollider;
    //Stores the collider of the hit ball
    private List<Collider> ballCollisionList = new List<Collider>();
    private Collider actualBallCollider;
    // Start is called before the first frame update

    
    private Transform figureTestTransform;
      private Transform targetBall;
    private GameObject ballGameObject;
    private GameObject figureTest;
    private Vector3 target;
    private Vector3 force;

    private Rigidbody ballRB;
    private Rigidbody  myrigidbody;




    void Start()
    {
        ballCollider = GetComponent<SphereCollider>();

        // figureTest = GameObject.FindGameObjectWithTag("Respawn");
        ballGameObject = GameObject.FindGameObjectWithTag("Respawn");
        targetBall = ballGameObject.transform;
        ballRB = ballGameObject.GetComponent<Rigidbody>();
        // myrigidbody = GetComponent<Rigidbody>();
         
        // target = new Vector3(figureTest.transform.position.x, figureTest.transform.position.y, figureTest.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Press grab button to grab ball
        if(Input.GetButtonDown("Fire2") ) {
          
            //   force = Vector3.MoveTowards(transform.position, target, 100 * Time.deltaTime);
            //   figureTest.GetComponent<Rigidbody>().AddForce(force * -700.0f);
                // Debug.Log ("FIRE2!!!=======: ");



         // Gets a vector that points from the target position to the player position.
          var heading = transform.position - targetBall.position;
          ballRB.AddForce (new Vector3(heading.x, 1, heading.z) * 50);





//  resultingForceAmount = attractionStrength * direction;


        }
        // if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)  )
        //     // ||
        //     if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) )
        //     //   if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) ) 
        //     //  if (Input.GetButtonDown("Fire2")) 
            
        // {
        //     Debug.Log("finger trigger is down");
        //     //List not empty
        //     if (ballCollisionList.Count > 0)
        //     {
        //         //Grab ball
        //         actualBallCollider = ballCollisionList[0];
        //         actualBallCollider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //         actualBallCollider.gameObject.transform.parent.gameObject.transform.parent = gameObject.transform;
        //         Debug.Log("Cacat");
        //     }
        //     Debug.Log("Pisat");
        // }




        // //Release button to let go
        // // if (Input.GetButtonUp("Fire2"))
        // //  if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) )
        //     // ||
        //     if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) )
        // {
       

        //         if (actualBallCollider!=null)
        //         {
        //             actualBallCollider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //             actualBallCollider.gameObject.transform.parent.gameObject.transform.parent = null;
        //             //Impart player velocity to the ball
        //             actualBallCollider.gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<CharacterController>().velocity;
        //         }
        // }




    }
    

    







    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "ball")
        {
            ballCollisionList.Add(collider);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "ball")
        {
             //Grab ball
              //  ballCollisionList[0].gameObject.GetComponent<Rigidbody>().isKinematic = false;
              //  ballCollisionList[0].gameObject.transform.parent.gameObject.transform.parent = null;
            ballCollisionList.Remove(collider);
        }
    }
}
