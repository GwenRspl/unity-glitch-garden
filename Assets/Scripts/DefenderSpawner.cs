using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    Defender defender;

    private void OnMouseDown() {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect) {
        this.defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPosition) {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = this.defender.GetStarCost();
        if (starDisplay.HaveEnoughStars(defenderCost)) {
            SpawnDefender(gridPosition);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickedPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickedPosition);
        Vector2 gridPosition = SnapToGrid(worldPosition);
        return gridPosition;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition) {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX, newY);

    }

    private void SpawnDefender(Vector2 roundedPosition) {
        Defender newDefender = Instantiate(this.defender, roundedPosition, Quaternion.identity) as Defender;
    }

}