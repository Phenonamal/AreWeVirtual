using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackGame : MonoBehaviour
{
    public LayerMask physicsLayer = -1;

    float radius = 6f;
    Vector3 origin;

    float timestamp;
    float spawnTime;
    float spawnInterval = 0.85f;
    float obstacleSpeed = 3f;

    [SerializeField] Transform m_ObsticlePrefab;
    Transform[] obstacles = new Transform[6];
    int activeIndex = -1;

    [SerializeField] Transform m_HackAvatar;
    Vector2 hackAvatarPosition = new Vector2();
    float hackAvatarSpeed = 8f;

    [SerializeField] AvatarScript m_Avatar;

    bool isDead;
    float restartTimestamp, restartDelay = 1f;

    // Use this for initialization
    void Start()
    {
        m_Avatar.OnHackingStateChangeEvent += this.gameObject.SetActive;
        m_HackAvatar.SetParent(this.transform);
        origin = m_HackAvatar.position;
        GameReset();
        this.gameObject.SetActive(m_Avatar.isHacking);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) { if (Time.time > restartTimestamp) GameReset(); }
        else GameUpdate(Time.deltaTime);
    }

    void GameUpdate(float deltaTime)
    {
        timestamp += deltaTime;
        if (timestamp > spawnTime)
        {
            spawnTime += spawnInterval;
            activeIndex = (activeIndex +1)%obstacles.Length;

            if (obstacles[activeIndex] == null) obstacles[activeIndex] = Instantiate<Transform>(m_ObsticlePrefab);
            obstacles[activeIndex].SetParent(this.transform);
            obstacles[activeIndex].localPosition = Quaternion.AngleAxis(360f * Random.value, Vector3.forward) * Vector3.up * radius;
            obstacles[activeIndex].LookAt(m_HackAvatar.position);
        }

        for (int i = 0; i < obstacles.Length; i++)
            if (obstacles[i] != null) obstacles[i].position += obstacles[i].forward * deltaTime * obstacleSpeed;

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        hackAvatarPosition += Vector2.ClampMagnitude(input, 1f) * deltaTime * hackAvatarSpeed;
        hackAvatarPosition = Vector2.ClampMagnitude(hackAvatarPosition, radius - 1f);
        m_HackAvatar.position = (Vector3)hackAvatarPosition + origin;

        bool isCollision = Physics.CheckSphere((Vector3)hackAvatarPosition + origin, 0.5f, physicsLayer, QueryTriggerInteraction.Ignore);
        if (isCollision) { isDead = true; restartTimestamp = Time.time + restartDelay; } //GameReset();
    }

    void GameReset()
    {
        isDead = false;
        timestamp = 0f;
        spawnTime = 0f;
        hackAvatarPosition = Vector2.zero;

        for (int i = 0; i < obstacles.Length; i++)
            if (obstacles[i] != null) obstacles[i].position = Vector3.up * -200f;
    }

    void OnTriggerEnter(){GameReset();}
}
