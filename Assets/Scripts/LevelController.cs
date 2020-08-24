using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject winLabel;
    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0;
    bool isLevelTimerFinished = false;

    private void Start() {
        this.winLabel.SetActive(false);
    }

    public void AttackerSpawned() {
        this.numberOfAttackers++;
    }

    public void AttackerKilled() {
        Debug.Log("Allo1");
        this.numberOfAttackers--;
        if (this.numberOfAttackers <= 0 && this.isLevelTimerFinished) {
            Debug.Log("Allo");
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition() {
        this.winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
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