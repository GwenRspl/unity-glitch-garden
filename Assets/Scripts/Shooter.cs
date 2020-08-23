using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile, gun;
    private AttackerSpawner myLaneSpawner;
    private Animator animator;

    private void Start() {
        SetLaneSpawner();
        this.animator = GetComponent<Animator>();
    }

    private void Update() {
        if (IsAttackerInLane()) {
            this.animator.SetBool("isAttacking", true);
        } else {
            this.animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners) {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - this.transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough) {
                this.myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane() {
        if (this.myLaneSpawner.transform.childCount <= 0) {
            return false;
        } else {
            return true;
        }
    }

    public void Fire() {
        Instantiate(this.projectile, this.gun.transform.position, this.gun.transform.rotation);
    }
}