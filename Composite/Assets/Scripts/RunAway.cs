using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : Steering
{
    public float runAwayCircle;
    public float safeRadius;

    public override Vector3 GetForce()
    {
        DesiredVelocity = (Position-Target);
        float distance = DesiredVelocity.magnitude;

        if (distance < runAwayCircle)
        {
            
                Debug.Log("RunAwayCircle");
                DesiredVelocity = DesiredVelocity.normalized * speed;
            
        }
        else if (distance > runAwayCircle && distance<safeRadius)
        {
            DesiredVelocity = DesiredVelocity.normalized * speed * (runAwayCircle/distance );
            Debug.Log("SafeRadious");
        }
        else
        {
            DesiredVelocity = Vector3.zero;
            
        }
        
        
        Vector3 steering = DesiredVelocity - Velocity;
        Debug.Log(Velocity);
        return steering;
    }
}
