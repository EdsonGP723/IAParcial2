using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public PathFollowing pathFollowing;
    public List<Transform> nodes = new();
    // Start is called before the first frame update
    void Start()
    {

       foreach(Transform node in nodes)
        {
            pathFollowing.nodes.Add(node.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
