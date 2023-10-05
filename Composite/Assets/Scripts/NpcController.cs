using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] List<Transform> targetPoints = new List<Transform>();

    public Seek Seek;

    private int _index = 1;

    public float distance;
    // Start is called before the first frame update

    private void Start()
    {
        NextPoint();
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,targetPoints[_index].position)<=distance)
        {
            NextPoint();
           
        }
        Debug.Log(_index);

    }

    private void NextPoint()
    {
        if (_index >= targetPoints.Count-1)
        {
            _index = 0;
        }
        else
        {
            _index++;
        }

        Seek.Target = targetPoints[_index].position;
    }
}
