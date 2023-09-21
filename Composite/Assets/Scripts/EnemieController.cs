using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
   public Vector3 target;

    public void FixedUpdate()
    {
        target = FindObjectOfType<PlayerController>().transform.position;
    }
}
