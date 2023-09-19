using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunAway : SteeringBehaviour
{
    public float runAwayCircle;
    public float safeRadius;
    public override Vector3 GetForce()
    {

        DesiredVelocity = (transform.position - Target).normalized * speed;

        runAwayCircle = DesiredVelocity.magnitude;

        if (runAwayCircle > safeRadius )
        {
            DesiredVelocity =DesiredVelocity.normalized * speed * (safeRadius / runAwayCircle);
            if (runAwayCircle > safeRadius * 6)
            {
                return DesiredVelocity = Vector3.zero;
            }
            Debug.Log("Fuera");
        }
        else
        {
            Debug.Log("Dentro");
            DesiredVelocity = DesiredVelocity.normalized *  speed;
        }


        return DesiredVelocity - Velocity;
    }
}
