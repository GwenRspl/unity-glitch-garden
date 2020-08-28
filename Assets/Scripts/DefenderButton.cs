﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour {
    [SerializeField] Defender defenderPrefab;

    private void Start() {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost() {
        Text costText = GetComponentInChildren<Text>();
        if (!costText) {
            Debug.LogError(this.name + " has no cost text, add one.");
        } else {
            costText.text = this.defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(71, 71, 71, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(this.defenderPrefab);
    }
}