using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile, gun;
    private AttackerSpawner myLaneSpawner;
    private Animator animator;
    GameObject projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start() {
        SetLaneSpawner();
        this.animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent() {
        this.projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!this.projectileParent) {
            this.projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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
        GameObject newProjectile = Instantiate(this.projectile, this.gun.transform.position, this.gun.transform.rotation) as GameObject;
        newProjectile.transform.parent = this.projectileParent.transform;
    }
}