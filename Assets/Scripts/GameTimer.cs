using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;

    private void Update() {
        if (this.triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / this.levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= this.levelTime);
        if (timerFinished) {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            this.triggeredLevelFinished = true;
        }
    }

}