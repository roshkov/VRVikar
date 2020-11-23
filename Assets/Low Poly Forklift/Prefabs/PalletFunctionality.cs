using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletFunctionality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Objects attachment
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Prop")
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Prop")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    //Forklift attachment
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Lift")
        {
            gameObject.transform.SetParent(collider.gameObject.transform);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Lift")
        {
            gameObject.transform.SetParent(null);
        }
    }
}
