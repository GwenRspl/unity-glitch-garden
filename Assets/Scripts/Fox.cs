﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherGameObject = otherCollider.gameObject;
        Debug.Log("trig");

        if (otherGameObject.GetComponent<Grave>()) {
            Debug.Log("grave");
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        } else if (otherGameObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(otherGameObject);
        }

    }

}