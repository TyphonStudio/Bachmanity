using UnityEngine.Networking;

public class NetworkSpawningModule : NetworkBehaviour {

    public static NetworkSpawningModule Local { get; private set; }

    public override void OnStartLocalPlayer()
    {
        Local = this;
    }

    [Command]
    public void CmdSpawnBarrelOnServer()
    {
        NetworkSpawner.Instance.SpawnOnServer();
    }

    [Command]
    public void CmdDestroyOnServer(NetworkInstanceId netId)
    {
        NetworkServer.Destroy(NetworkServer.FindLocalObject(netId));
    }
}
