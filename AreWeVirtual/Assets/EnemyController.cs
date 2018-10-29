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
    public CharacterController PlayerRadius;
    public CharacterController EnemyRadius;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine("EnemyMoving");
    }

    IEnumerator EnemyMoving()
    {
        Enemy.transform.position += new Vector3(Random.Range(0.5f * speed, 3.0f * speed) * Time.deltaTime, 0.0f,Random.Range(0.5f * speed, 7.0f * speed) * Time.deltaTime);
        if (EnemyRadius.radius < PlayerRadius.radius)
        {
            Enemy.transform.position += new Vector3(Avatar.transform.position.x / 4, 0, Avatar.transform.position.x / 2);
        }

        yield return false;
    }

}