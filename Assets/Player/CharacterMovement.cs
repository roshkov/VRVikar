using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float pushPower = 2.0f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        //No rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // No pushing objects underneath us
        if (hit.moveDirection.y < 0)
        {
            return;
        }

        //Calculate push direciton from move direction and apply push
        Vector3 pushDir = hit.moveDirection;
        body.velocity = pushDir * pushPower * speed;
    }
   
}
