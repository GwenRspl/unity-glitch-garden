using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10f;

    private void Update() {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / this.levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= this.levelTime);
        if (timerFinished) {
            Debug.Log("level timer finshed");
        }
    }

}