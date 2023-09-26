using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float obstacleRadius;
    [SerializeField] private int obstacles;

    public List<GameObject> Obstacles => _obstacles;
	private List<GameObject> _obstacles = new List<GameObject>();

    void Start()
    {
        CreateObstacle();
    }

    private int index = 1;

    void CreateObstacle(int timesCalled = 0)
    {
        Vector3 randPos = (Random.insideUnitSphere * obstacleRadius) +transform.position ;
        randPos.y = transform.position.y;
        foreach (var obstacle in _obstacles)
        {
            var distance = Vector3.Distance(obstacle.transform.position, randPos);
            if (distance > obstacle.transform.localScale.x + .05f && distance > obstacle.transform.localScale.z + .05f)
            {
                continue;
            }

            if (timesCalled > 25)
            {
                Debug.Log("No more Avaliable Positions");
                return;
            }
            CreateObstacle(++timesCalled);

            return;
        }

        var newObstacle = Instantiate(obstaclePrefab, randPos, Quaternion.identity);
        _obstacles.Add(newObstacle);
        if (++index > obstacles) { return; }
        CreateObstacle();

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, obstacleRadius);
    }


}
