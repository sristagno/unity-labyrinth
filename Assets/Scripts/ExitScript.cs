using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ExitScript : MonoBehaviour
{
    [FormerlySerializedAs("LevelToLoad")] [SerializeField] private int levelToLoad;
    [FormerlySerializedAs("AutoIndex")] [SerializeField] private bool autoIndex = true;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (autoIndex)
        {
            levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            if (levelToLoad >= SceneManager.sceneCountInBuildSettings)
            {
                levelToLoad = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("LastLevel", levelToLoad);
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
