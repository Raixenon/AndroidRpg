﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string lvl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            SceneManager.LoadSceneAsync(lvl);
            
        }
    }
}
