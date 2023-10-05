using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Steering steeringBehaviour;
    void Update()
    {
        steeringBehaviour.Target = target.position;
    }

  
}
