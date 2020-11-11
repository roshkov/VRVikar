using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBoxScript : MonoBehaviour
{
  
    private GameObject TargetSpawner;
    AudioSource audioData;
    // public AudioClip otherClip;
    
    void Start()
    
    {
        TargetSpawner = GameObject.FindGameObjectWithTag("TargetSpawner");
        audioData = GetComponent<AudioSource>();
    
    }

   void OnCollisionEnter(Collision collision){

        if(collision.gameObject.tag == "ball"){
            audioData.Play();
            Destroy(this.gameObject);
            TargetSpawner.GetComponent<TargetSpawner>().setNeedSpawn();
            TargetSpawner.GetComponent<TargetSpawner>().increaseScore();

        }

    


 }


}
