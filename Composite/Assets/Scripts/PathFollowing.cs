using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : Steering
{
    public List<Vector3> nodes;

    public float pathRadious;

    public bool looping;

    private int _currentNode=0;

    private int _pathDirection;
    public override Vector3 GetForce()
    {
        Target = nodes[_currentNode];

        if (Vector3.Distance(transform.position, Target) <= pathRadious)
        {
            if (_pathDirection == 0)
            {
                _currentNode++;
                if (_currentNode >= nodes.Count)
                {
                    if (looping)
                    {
                        _currentNode = nodes.Count - 1;
                        _pathDirection = 1;
                    }
                    else
                    {
                        _currentNode = nodes.Count - 1;
                    }
                }
            }
            else if (_pathDirection == 1)
            {
                _currentNode--;
                if (_currentNode<=0)
                {
                    if (looping)
                    {
                        _currentNode = 0;
                        _pathDirection = 0;
                    }
                    else
                    {
                        _currentNode = 0;
                    }
                }
            }

        }
        return Seek();
    }
   
    private Vector3 Seek()
    {
         Vector3 steering = new Vector3();
        DesiredVelocity = (Target - Position);

        float distance = DesiredVelocity.magnitude;
        var slowingRadious = 1;


        if (distance < slowingRadious)
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
