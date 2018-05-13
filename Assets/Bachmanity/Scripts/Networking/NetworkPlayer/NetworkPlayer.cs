using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkInputModule))]
[RequireComponent(typeof(NetworkSpawningModule))]
public class NetworkPlayer : NetworkBehaviour {

    public static NetworkPlayer Local { get; private set; }
    public NetworkInputModule Input { get; private set; }
    public NetworkSpawningModule Spawning { get; private set; }

    private void Awake()
    {
        Input = GetComponent<NetworkInputModule>();
        Spawning = GetComponent<NetworkSpawningModule>();
    }

    public override void OnStartLocalPlayer()
    {
        Local = this;
    }
}
