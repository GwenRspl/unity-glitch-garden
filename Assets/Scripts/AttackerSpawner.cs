using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;

    IEnumerator Start() {
        while (this.spawn) {
            yield return new WaitForSeconds(Random.Range(this.minSpawnDelay, this.maxSpawnDelay));
            SpawnAttacker();
        }

    }

    public void StopSpawning() {
        this.spawn = false;
    }

    private void SpawnAttacker() {
        Attacker attacker = this.attackerPrefabArray[Random.Range(0, this.attackerPrefabArray.Length)];
        Spawn(attacker);
    }

    private void Spawn(Attacker attacker) {
        Attacker newAttacker = Instantiate(attacker, this.transform.position, this.transform.rotation) as Attacker;
        newAttacker.transform.parent = this.transform;
    }
}