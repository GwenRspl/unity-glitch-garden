using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker attackerPrefab;

    IEnumerator Start() {
        while (this.spawn) {
            yield return new WaitForSeconds(Random.Range(this.minSpawnDelay, this.maxSpawnDelay));
            SpawnAttacker();
        }

    }

    private void SpawnAttacker() {
        Attacker newAttacker = Instantiate(this.attackerPrefab, this.transform.position, this.transform.rotation) as Attacker;
        newAttacker.transform.parent = this.transform;
    }

    void Update() {

    }
}