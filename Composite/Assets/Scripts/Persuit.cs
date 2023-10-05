using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persuit : Steering
{
    public int T=30;

    public GameObject persuitTarget;

    private PlayerController _pController;

    private void Start()
    {
        _pController = persuitTarget.GetComponent<PlayerController>();
    }
    public override Vector3 GetForce()
    {
        Position = Target + (_pController.Velocity * T);

        //  position = position-transform.position;

        //Steering


        
        return Seek();
    }

    private Vector3 Seek()
    {
        Vector3 desired_velocity = (Position - transform.position).normalized * speed;

        Vector3 steering = desired_velocity - Velocity;
        return steering;
    }
}
