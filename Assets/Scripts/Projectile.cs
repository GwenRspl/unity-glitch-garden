using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed = 4f;
    [SerializeField] float damage = 50;

    void Update() {
        this.transform.Translate(Vector2.right * this.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (attacker && health) {
            health.DealDamage(this.damage);
            Destroy(this.gameObject);
        }
    }
}