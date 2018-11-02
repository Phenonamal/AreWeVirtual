using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkIndicator : MonoBehaviour {
    public Transform a, b;

	// Use this for initialization
	void Start () {
		
	}
	// change selection active, second, third
	// Update is called once per frame
	void Update () {
        Vector3 delta = b.position - a.position;
        transform.position = a.position + (delta * 0.5f);
        transform.rotation = Quaternion.LookRotation(delta);
        Vector3 scale = Vector3.one;
        scale.z = delta.magnitude;
        transform.localScale = scale;
	}
    // Hack
    // Trade

    //scale in (while looking)
    //Pause
    //Red 1.5 second, glitch effect, beep
    //restart
    //Yellow, click
    //
}
