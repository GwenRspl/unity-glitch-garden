using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile, gun;

    public void Fire() {
        Instantiate(this.projectile, this.gun.transform.position, this.gun.transform.rotation);
    }
}