using UnityEngine;
using UnityEngine.Networking;

public class NetworkSpawningModule : NetworkBehaviour
{

    public static NetworkSpawningModule Local { get; private set; }

    public override void OnStartLocalPlayer()
    {
        Local = this;
    }

    [Command]
    public void CmdSpawnBarrelOnServer()
    {
        BarrelSpawner.Instance.SpawnOnServer();
    }

    [Command]
    public void CmdDestroyOnServer(NetworkInstanceId netId)
    {
        NetworkServer.Destroy(NetworkServer.FindLocalObject(netId));
    }

    [Command]
    public void CmdDestroyWithEffect(NetworkInstanceId objId)
    {
        var obj = NetworkServer.FindLocalObject(objId);
        //RpcPlayEffect(obj.transform.position);
        NetworkServer.Destroy(obj);
    }

    [ClientRpc]
    void RpcPlayEffect(Vector2 pos)
    {
        //if (NetworkPlayer.Local.netId != initiatorId)
            EffectSpawner.Instance.SpawnAndPlay(pos);
    }
}
