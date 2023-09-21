using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    public List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();
    public Rigidbody rb;
    public Vector3 velocity;
	public Vector3 totalforce = Vector3.zero;
	public float maxForce= 5f;
	public float maxSpeed = 5;

    private void FixedUpdate()
	{
		totalforce= Vector3.zero;
        
        foreach (SteeringBehaviour behaviour in behaviours) {

	                  
	        behaviour.Position = transform.position;
	        behaviour.Velocity = velocity;
            totalforce += behaviour.GetForce();

        }

		velocity = Vector3.ClampMagnitude(velocity + totalforce, maxForce);

	    transform.position += velocity * Time.deltaTime;
       
        
    }
}
