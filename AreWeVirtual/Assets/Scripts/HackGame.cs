using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackGame : MonoBehaviour
{
    float timestamp;
    float spawnTime;
    float spawnInterval = 1f;

    Vector2 hackAvatarPosition = new Vector2();
    float hackAvatarSpeed = 8f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GameUpdate(float deltaTime)
    {
        timestamp += deltaTime;
        if (timestamp > spawnTime)
        {
            spawnTime += spawnInterval;
        }

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        hackAvatarPosition += Vector2.ClampMagnitude(input, 1f) * deltaTime * hackAvatarSpeed;
    }

    void GameReset()
    {
        timestamp = 0f;
        spawnTime = 0f;
    }
}
