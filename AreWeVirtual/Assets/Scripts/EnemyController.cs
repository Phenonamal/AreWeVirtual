using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float range = 3.0f;
    public GameObject Enemy;
    public float speed = 1.0f;
    Vector3 moveDirection;
    public RaycastHit ray;
    public GameObject Avatar;
    private Vector3 AvatarVector;
    private Vector3 EnemyVector;
    private float NewRange;
    public new Rigidbody rigidbody;
    public float jumpVelocity = 3.0f;
    public bool isTouchingFloor = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rigidbody = GetComponent<Rigidbody>();
        /*
        Enemy.transform.position += new Vector3(Random.Range(0.5f * speed, 3.0f * speed) * Time.deltaTime, 0.0f, Random.Range(0.5f * speed, 7.0f * speed) * Time.deltaTime);
        if (EnemyRadius.radius < PlayerRadius.radius)
        {
            Enemy.transform.position += new Vector3(Avatar.transform.position.x / 4, 0, Avatar.transform.position.x / 2);
        }
        */
        Enemy.transform.LookAt(Avatar.transform);

        EnemyRangeHandler();
    }

    public void EnemyRangeHandler()
    {
        Vector3 NewVector = Avatar.transform.position - Enemy.transform.position;

    float Length = NewVector.magnitude;

        NewRange = Length - range;


    if (NewRange < range)
        {
            if (isTouchingFloor == true)
            {
                rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
                rigidbody.MovePosition(Vector3.forward * speed);
                isTouchingFloor = false;
            } else
            {
                isTouchingFloor = false;
            }
        } 
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isTouchingFloor = true;
        }
    }
}