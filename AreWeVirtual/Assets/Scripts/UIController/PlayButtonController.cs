﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonController : MonoBehaviour {

    public void LoadGame()
    {
        SceneManager.LoadScene("Play");
    }
}
