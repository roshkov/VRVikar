using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftForkController : MonoBehaviour
{
 
    public Transform fork; 
    // public Transform mast;
    public float speedTranslate; //Platform travel speed
    
    public float speedRotate;
    public float maxY; //The maximum height of the platform
    public float minY; //The minimum height of the platform

    public float maxRotate;
    public float minRotate;




    void FixedUpdate () {
      
        
        // Lift fork up
        if (Input.GetKey(KeyCode.PageUp))
        {
            Debug.Log("fork.transform.position.y  " + fork.transform.position.y + "   maxY: " + maxY);
            if (fork.transform.position.y <= maxY) {

                    fork.Translate(Vector3.up * speedTranslate/10 * Time.deltaTime);
                  
                } ; 
        
        }

        // Lift fork down
        if (Input.GetKey(KeyCode.PageDown))
        {
            Debug.Log("down");
             if (fork.transform.position.y >= minY) {

                    fork.Translate(Vector3.down * speedTranslate/10 * Time.deltaTime);
 
             }

        }


        // Rotating fork upwards
        if (Input.GetKey(KeyCode.UpArrow))
        {
         
            if (fork.rotation.x >= maxRotate/100) {
                     Debug.Log("upArrorw" + fork.rotation.x + "  ===  " + maxRotate/100);
                     fork.Rotate(Vector3.left * speedRotate * Time.deltaTime);
                  
                } ; 
        
        }
        

        // Rotating fork downwards
        if (Input.GetKey(KeyCode.DownArrow))
        {
          
            if (fork.rotation.x <= minRotate/100) {

                    Debug.Log("downArrow" + fork.rotation.x);
                    fork.Rotate(Vector3.right * speedRotate * Time.deltaTime);
                  
                } ; 
        
        }



    



    }


}
