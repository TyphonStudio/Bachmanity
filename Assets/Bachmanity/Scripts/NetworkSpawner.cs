using UnityEngine;
using UnityEngine.Networking;

// Exists only on server, gets calls from player commands only
public class NetworkSpawner : NetworkBehaviour {

    public static NetworkSpawner Instance { get; private set; }

    public GameObject prefab;
    Vector2 spawnPosition;

    [Server]
    public void SpawnOnServer()
    {
        spawnPosition.x = Random.Range(-5.0f, 5.0f);
        spawnPosition.y = Random.Range(-5.0f, 5.0f);
        var obj = Instantiate(prefab, spawnPosition, Quaternion.identity);
        NetworkServer.Spawn(obj);
    }

    private void Awake()
    {
        Instance = this;
    }
}
