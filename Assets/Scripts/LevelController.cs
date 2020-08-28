using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0;
    bool isLevelTimerFinished = false;
    bool lostLevel = false;

    private void Start() {
        this.winLabel.SetActive(false);
        this.loseLabel.SetActive(false);
    }

    public void AttackerSpawned() {
        this.numberOfAttackers++;
    }

    public void AttackerKilled() {
        this.numberOfAttackers--;
        if (this.numberOfAttackers <= 0 && this.isLevelTimerFinished && this.lostLevel == false) {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition() {
        this.winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition() {
        this.lostLevel = true;
        this.loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished() {
        this.isLevelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray) {
            spawner.StopSpawning();
        }
    }
}