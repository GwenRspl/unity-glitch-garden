using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    [SerializeField] int stars = 100;
    Text starText;

    private void Start() {
        this.starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        this.starText.text = this.stars.ToString();
    }

    public bool HaveEnoughStars(int amount) {
        return this.stars >= amount;
    }

    public void AddStars(int amount) {
        this.stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount) {
        if (this.stars >= amount) {
            this.stars -= amount;
            UpdateDisplay();
        }

    }

}