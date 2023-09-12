using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public float speed;
    public Vector3 DesiredVelocity;
    public Vector3 Velocity;
    public Vector3 Position;
    public Vector3 Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract Vector3 GetForce();
}
