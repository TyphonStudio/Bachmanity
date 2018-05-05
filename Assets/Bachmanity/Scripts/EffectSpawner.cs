using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour {

    public static EffectSpawner Instance { get; private set; }

    public GameObject effectPrefab;
    public Vector2 offset;

    Effect lastSpawned;

    protected void Awake()
    {
        Instance = this;
    }

    public void SpawnAndPlay(Vector2 position)
    {
        lastSpawned = Instantiate(effectPrefab, position + offset, Quaternion.identity).GetComponent<Effect>();
        lastSpawned.PlayEffectAndDestroy();
    }
}
