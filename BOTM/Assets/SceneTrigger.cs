﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public string SceneName = "default";

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag.Equals("Player"))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
