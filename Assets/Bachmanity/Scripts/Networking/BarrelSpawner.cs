using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BarrelSpawner : NetworkBehaviour {

    public static BarrelSpawner Instance { get; private set; }

    protected void Awake()
    {
        Instance = this;
    }

    public GameObject prefab;
    Vector2 spawnPosition;

    [Server]
    public void SpawnOnServer(Vector2 spawnPosition)
    {
        var obj = Instantiate(prefab, spawnPosition, Quaternion.identity);
        NetworkServer.Spawn(obj);
    }
}
