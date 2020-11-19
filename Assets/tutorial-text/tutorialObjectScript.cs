using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialObjectScript : MonoBehaviour
{
    public GameObject tutorialTextPrefab;
    public int offsetTop = 2;


    void OnCollisionEnter(Collision collision)
    {
        // ContactPoint contact = collision.contacts[0];
        // Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        // Vector3 position = contact.point;
        Instantiate(tutorialTextPrefab, new Vector3(transform.position.x, transform.position.y + offsetTop), transform.rotation);


    }
 
    private void OnTriggerEnter(Collider other)
        {
         Debug.Log ("OnTriggerEnter ");
        }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log ("OnTriggerExit ");
    }



}
