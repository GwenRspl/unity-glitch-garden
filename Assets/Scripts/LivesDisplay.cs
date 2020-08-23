using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {

    [SerializeField] int lives = 5;
    [SerializeField] int damage = 1;
    Text livesText;

    private void Start() {
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
            FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }
}