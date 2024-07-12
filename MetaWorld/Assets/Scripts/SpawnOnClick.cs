using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{
    public GameObject spawn = null;
    public Transform spawnPosition;
    public void Spawn()
    {
        if(spawn != null && spawnPosition != null) {
            var _spawn = Instantiate(spawn);
            _spawn.transform.position = spawnPosition.position + Vector3.zero;
        }
    }
}
