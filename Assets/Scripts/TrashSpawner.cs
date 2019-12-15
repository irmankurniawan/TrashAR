using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public Transform[] pos;
    public GameObject[] trashs;

    bool CheckEmptyPos(Transform pos) {
        if(pos.childCount == 0) {
            return true;
        }
        else return false;
    }

    void Start()
    {
        StartCoroutine(SpawnTrash());
    }

    void Spawn() {
        for(var i=0; i<4; i++) {
            if(CheckEmptyPos(pos[i])) {
                //RandomSpawn();
                int rand = Random.Range(0,3);
                Instantiate(trashs[rand], pos[i].position, pos[i].rotation, pos[i]);
                return;
            }
        }
    }

    IEnumerator SpawnTrash() {
        while(true) {
            yield return new WaitForSeconds(5.0f);
            Spawn();
        }
    }

}
