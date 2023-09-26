using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoid : SteeringBehaviour
{
	public ObstacleController obController;
	public float maxSeeAhead;
	public float obstacleRadius;
	public float maxAvoidForce;
	public bool showVectors;
	
	private List <Vector3> _obstacleList = new List<Vector3>();
	private Vector3 _ahead, _ahead2;
	
	private void Start()
	{
		
	}
	
	protected void FixedUpdate()
	{
		_ahead = Position + Velocity.normalized * maxSeeAhead;
		_ahead2 = Position + Velocity.normalized * maxSeeAhead * 0.5;
	}
	
	public override Vector3 GetForce()
	{
		DesiredVelocity = (Target - Position).normalized * speed;
		return DesiredVelocity - Velocity;
	}
	
	private Vector3? FindBiggestThreat()
	{
		//var mostThreatening = gameObject.null;
		return Vector3.zero;
	}
	
	private bool CollisionDetected(Vector3 v1, Vector3 v2, Vector3 v3)
	{
		var mostThreatening = FindBiggestThreat();
		var avoidance = new Vector3(0,0,0);
		
		if (mostThreatening != null)
		{
			avoidance.x = _ahead.x;
		}
		
		
	}
	
	private void DrawVectors(Vector3 vectors)
	{
		
	}
	
	
	
}
