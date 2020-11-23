using UnityEngine;
using System.Collections;

public class PalletDragScript : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
          if (rb.velocity.magnitude <0.05f) {
              rb.drag = 20f;
          }
          else {
              rb.drag = 0f;
          }
    }
}