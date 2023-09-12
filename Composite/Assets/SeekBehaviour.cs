using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeekBehaviour : SteeringBehaviour
{

   

    public override Vector3 GetForce()
    {
        DesiredVelocity = (Target - transform.position).normalized * speed;

        return DesiredVelocity - Velocity;
    }

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
       

    }
}
