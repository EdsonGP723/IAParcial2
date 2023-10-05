using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed;
    public Rigidbody rigidBody;
    public Vector3 Velocity;
    // Update is called once per frame
    void Update()
    {
        Move(GetInput());
       // transform.Rotate(0, 1 * Time.deltaTime * speed, 0);
        Velocity = rigidBody.velocity;
    }

    Vector2 GetInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    private void Move(Vector2 axys)
    {
        transform.Translate(new Vector3(axys.x,0,axys.y)*speed*Time.deltaTime);
    }
}
