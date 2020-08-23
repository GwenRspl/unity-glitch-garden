using System;
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
        SceneManager.LoadScene(1);
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(this.currentSceneIndex + 1);
    }

    public void LoadYouLose() {
        SceneManager.LoadScene("GameOverScreen");
    }
}