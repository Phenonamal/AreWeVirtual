﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {
    public void CompleteLevel(AvatarScript avatar) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 , LoadSceneMode.Single); }
}
