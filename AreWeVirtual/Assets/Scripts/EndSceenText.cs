using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndSceenText : MonoBehaviour {
    [SerializeField] private TextMeshPro TextUI;
    private float rotationSpeed = 18.5f;

    void Update()
    {
        
        TextUI.transform.rotation = Quaternion.AngleAxis(Time.time *  rotationSpeed, Vector3.up);
    }

}
