using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeekBehaviour : SteeringBehaviour
{

   

    public override Vector3 GetForce()
    {
	    DesiredVelocity = (Target - Position).normalized * speed;


        return DesiredVelocity - Velocity;
    }

   
}
