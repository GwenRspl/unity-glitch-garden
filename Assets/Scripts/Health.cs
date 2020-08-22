using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage) {
        this.health -= damage;
        if (this.health <= 0) {
            TriggerDeathVFX();
            Destroy(this.gameObject);
        }
    }

    private void TriggerDeathVFX() {
        if (!this.deathVFX) {
            return;
        }
        GameObject deathVFXObject = Instantiate(this.deathVFX, this.transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }
}