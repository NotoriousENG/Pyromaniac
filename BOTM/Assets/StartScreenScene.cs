﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScene : MonoBehaviour
{

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
