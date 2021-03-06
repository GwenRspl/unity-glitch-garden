﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    int currentSceneIndex;
    [SerializeField] int timeToWait = 4;

    private void Start() {
        this.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (this.currentSceneIndex == 0) {
            StartCoroutine(WaitAndLoadStartScreen());
        }
    }

    IEnumerator WaitAndLoadStartScreen() {
        yield return new WaitForSeconds(this.timeToWait);
        LoadNextScene();
    }

    public void LoadStartScreen() {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadOptionsScreen() {
        Time.timeScale = 1;
        SceneManager.LoadScene("OptionsScreen");
    }

    public void RestartScreen() {
        Time.timeScale = 1;
        SceneManager.LoadScene(this.currentSceneIndex);
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(this.currentSceneIndex + 1);
    }

    public void LoadYouLose() {
        SceneManager.LoadScene("GameOverScreen");
    }

    public void QuitGame() {
        Application.Quit();
    }
}