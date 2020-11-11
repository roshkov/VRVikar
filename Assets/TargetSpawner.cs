using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetSpawner : MonoBehaviour
{

     public GameObject TargetPrefab;
  
     public GameObject PlayPlane;
     private GameObject newTarget;

     public GameObject Canvas;

     private bool needSpawn = false;

     private int scores;

     private int timeLeft;
     

     TextMeshPro TimeText;
     TextMeshPro ScoresText;


    void Start()
    {
         timeLeft = 120;
         scores = 0;
         spawnNewTarget();
         StartCoroutine(TimeCount());
         TimeText = GameObject.FindWithTag("TimeText").GetComponent<TextMeshPro>();
         ScoresText = GameObject.FindWithTag("ScoresText").GetComponent<TextMeshPro>();


    }

    // Update is called once per frame
    void Update()
    {
        
        if (needSpawn) {
            spawnNewTarget();
        }
    }


    public void spawnNewTarget() {
        needSpawn = false;
        newTarget =  Instantiate(TargetPrefab, new Vector3(Random.Range (0, 15 ), Random.Range (1, 3 ), Random.Range (-10,10)), Quaternion.identity);

    }

    public void setNeedSpawn () {
        needSpawn = true;
    }

    public void increaseScore() {
        scores++;
        ScoresText.SetText($"Score: {scores}");

    } 

  IEnumerator TimeCount() {

   while (timeLeft > 0 ) {   
    yield return new WaitForSeconds(1);
    
    timeLeft--; 
    TimeText.SetText($"Time: {timeLeft}");

    }
     TimeText.SetText("Time's up!");
  }
}
