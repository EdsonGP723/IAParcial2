using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    public List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();
    public Rigidbody rb;
    public Vector3 velocity;
    public Vector3 totalforce = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        totalforce= Vector3.zero;
        foreach (SteeringBehaviour behaviour in behaviours) {

            totalforce += behaviour.GetForce();
        
        }

        velocity += totalforce;
        transform.position += velocity * Time.deltaTime;
    }
}
