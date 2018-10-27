using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCamera : MonoBehaviour {
    [SerializeField] Text m_LevelText;

	void Start () {
        if (m_LevelText != null) m_LevelText.text = "Level " + SceneManager.GetActiveScene().buildIndex;

    }
	

	void Update () {
		
	}
}
