using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public Vector3 direction = Vector3.forward;
    [Range(0f,1f)] public float t = 0f;
    public float duration = 2f;

    Vector3 originPosition;
    float offsetTime;

    new Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = this.GetComponent<Rigidbody>();
        offsetTime = t - (Time.time/ duration);
        originPosition = this.transform.position - (direction * t);
    }
	
	// Update is called once per frame
	void Update () {
        t = Mathf.PingPong(offsetTime + (Time.time/ duration), 1f);
        Vector3 pos = originPosition + (direction * t);
        rigidbody.MovePosition(pos);
	}

    void OnDrawGizmos()
    {
        Vector3 a = this.transform.position - (direction * t);
        Vector3 b = this.transform.position + (direction * (1f-t));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(a, b);
    }
}
