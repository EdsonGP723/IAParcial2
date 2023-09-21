using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
	public List<Vector3> targetPoints = new List<Vector3>();
	public SeekBehaviour seek;
	public float distance;
	private int _index = 0;

    void Update()
    {
	    var actualPoint = targetPoints[_index];
	    
	    if (Vector3.Distance(actualPoint,transform.position)< distance){
	    	nextPoint();
	    }
	    seek.Target = targetPoints[_index];
    }
	
	void nextPoint()
	{
		if (_index == targetPoints.Count - 1){
			_index = 0;
		}
		else {
			_index ++;
		}
	}
    
 
 
}
