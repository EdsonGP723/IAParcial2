using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Steering
{
    public bool arrival;
    public float slowingRadious;
    
    public override Vector3 GetForce()
    {
        Vector3 steering = new Vector3();
        DesiredVelocity = (Target - Position);

        float distance = DesiredVelocity.magnitude;

        if (arrival && distance < slowingRadious)
        {
                DesiredVelocity = DesiredVelocity.normalized * speed * (distance / slowingRadious);
        }
        else
        {
            DesiredVelocity = DesiredVelocity.normalized * speed;
        }

        steering = DesiredVelocity - Velocity;
        
        return steering;
    }
}
