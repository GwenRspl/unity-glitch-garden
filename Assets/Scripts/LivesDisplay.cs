using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {

    [SerializeField] float baseLives = 3f;
    [SerializeField] int damage = 1;
    float lives;
    Text livesText;

    private void Start() {
        this.lives = this.baseLives - PlayerPrefsController.GetDifficulty();
        this.livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        this.livesText.text = this.lives.ToString();
    }

    public void TakeLife() {
        this.lives -= this.damage;
        UpdateDisplay();
        if (this.lives <= 0) {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}