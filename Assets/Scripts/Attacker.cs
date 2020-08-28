using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(0f, 5f)]
    float currentSpeed = 0f;
    GameObject currentTarget;

    private void Awake() {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy() {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null) {
            levelController.AttackerKilled();
        }
    }

    void Update() {
        this.transform.Translate(Vector2.left * this.currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        if (!this.currentTarget) {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed) {
        this.currentSpeed = speed;
    }

    public void Attack(GameObject target) {
        GetComponent<Animator>().SetBool("isAttacking", true);
        this.currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) {
        if (!this.currentTarget) { return; }
        Health health = this.currentTarget.GetComponent<Health>();
        if (health) {
            health.DealDamage(damage);
        }
    }
}