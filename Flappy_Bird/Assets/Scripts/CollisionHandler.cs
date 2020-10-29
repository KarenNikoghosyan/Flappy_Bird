﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI pipeScore;

    bool isChangeable = true, isValid = true;
    
    int score = 0;

    void Start()
    {
        pipeScore.text = score.ToString();
    }

    void Update()
    {
        if (Debug.isDebugBuild) 
        {
            DebugKeys();
        }
    }

    private void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            score += 9;
            pipeScore.text = score.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Environment")
        {
            KillPlayer();
        }

        if (other.gameObject.tag == "Score")
        {
            AddScore();
            UpdatePipeColorAndSpeed();
        }
    }

    private void KillPlayer()
    {
        Destroy(gameObject, 1f);
        SceneManager.LoadScene(0); // todo remove this line of code - after adding main menu, pause and restart functionality.
    }

    private void AddScore()
    {
        score++;
        pipeScore.text = score.ToString();
    }
    private void UpdatePipeColorAndSpeed()
    {
        if (score % 10 == 0)
        {
            FindObjectOfType<PipesSpawner>().SetRandomColor(isChangeable);
            FindObjectOfType<PipesSpawner>().ChangeSpawnSpeed(isValid);
            FindObjectOfType<PipesMovement>().SpeedUpMovement(isValid);
        }
    }

}
