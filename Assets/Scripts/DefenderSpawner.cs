using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    [SerializeField] GameObject defender;

    private void OnMouseDown() {
        SpawnDefender(GetSquareClicked());
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
        GameObject newDefender = Instantiate(this.defender, roundedPosition, Quaternion.identity) as GameObject;
    }

}