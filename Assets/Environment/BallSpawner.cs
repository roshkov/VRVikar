using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject BallPrefab;
    private GameObject newBall;

    // Start is called before the first frame update
    void Start()

    {
        newBall = Instantiate(BallPrefab, gameObject.transform.position, Quaternion.identity);
    }


}
