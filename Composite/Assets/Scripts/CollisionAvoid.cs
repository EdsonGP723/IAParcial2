using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoid : Steering
{

    public ObstacleController obController;
    public float maxSeeAhead;
    public float obstacleRadious;
    public float maxAvoidForce;
    public bool showVectors;

    private List<Vector3> _obstacleList = new List<Vector3>();
    private Vector3 _ahead, _ahead2;
    // Start is called before the first frame update
     private void Start()
    {
        foreach(GameObject obstacle in obController.Obstacles) {

            _obstacleList.Add(obstacle.transform.position);
        }
        Debug.Log(_obstacleList.Count);
    }

    public override Vector3 GetForce()
    {
        _ahead = Position + Velocity.normalized * maxSeeAhead;
        _ahead2 = Position + Velocity.normalized * maxSeeAhead * 0.5f;

        DrawVectors(_ahead,Color.yellow);

        var mosThreatening = FindBiggestThreat();
        var avoidance = Vector3.zero;

        if (mosThreatening != null)
        {
            DrawVectors(mosThreatening.Value,Color.red);
            avoidance.x = _ahead.x - mosThreatening.Value.x;
            avoidance.y = _ahead.y - mosThreatening.Value.y;

            avoidance = avoidance.normalized;

            avoidance *= maxAvoidForce;

        }
        else
        {
            avoidance = Vector3.zero;
        }

        return avoidance;

    }

    private Vector3? FindBiggestThreat()
    {
        Vector3? mostThreatening = null;
        bool collision = false;
       

        foreach (Vector3 obstaclePos in _obstacleList)
        {
            float distanceAhead1 = Mathf.Abs(Vector3.Distance(obstaclePos, _ahead));
            float distanceAhead2 = Mathf.Abs(Vector3.Distance(obstaclePos, _ahead2));

            if (distanceAhead1 <= obstacleRadious || distanceAhead2 <= obstacleRadious)
            {
                collision = true;
            }
            else
            {
                collision = false;
            }

            if(collision&&(mostThreatening==null || Mathf.Abs(Vector3.Distance(obstaclePos, Position)) < Mathf.Abs(Vector3.Distance(mostThreatening.Value, Position)))){
                mostThreatening = obstaclePos;
            }

        }
        return mostThreatening;
    }

    private void DrawVectors(Vector3 V3, Color color)
    {
        Debug.DrawLine(transform.position, V3, color);
    }
}
