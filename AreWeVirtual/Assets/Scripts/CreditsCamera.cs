using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsCamera : MonoBehaviour
{
    [SerializeField] private Camera _CreditsCamera;
    private float scrollSpeed = 2.0f;


	// Update is called once per frame
	void Update ()
	{
	    if (Time.time < 33f)
	    {

	        _CreditsCamera.transform.position -= new Vector3(0, Time.deltaTime * scrollSpeed, 0);
	    }

	    if (Time.time > 40f)
	    {
            Application.Quit();
	    }

    }
}
