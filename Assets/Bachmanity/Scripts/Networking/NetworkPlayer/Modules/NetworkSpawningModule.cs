using UnityEngine;
using UnityEngine.Networking;

public class NetworkSpawningModule : NetworkBehaviour
{
    public static NetworkSpawningModule Local { get; private set; }

    private Vector2 spawnPosition;

    public override void OnStartLocalPlayer()
    {
        Local = this;
    }

    [Command]
    public void CmdSpawnBarrelOnServer()
    {
        spawnPosition.x = Random.Range(-5.0f, 5.0f);
        spawnPosition.y = Random.Range(-5.0f, 5.0f);

        BarrelSpawner.Instance.SpawnOnServer(spawnPosition);
    }

    [Command]
    public void CmdDestroyWithEffect(NetworkInstanceId objId, NetworkInstanceId initiator)
    {
        Debug.Log("destoy command initiate by " + initiator.Value);
        var obj = NetworkServer.FindLocalObject(objId);
        RpcPlayEffect(obj.transform.position, initiator);
        NetworkServer.Destroy(obj);
    }

    [ClientRpc]
    void RpcPlayEffect(Vector2 pos, NetworkInstanceId initiator)
    {
        Debug.Log("effect initiated by " + initiator.Value);

        // if this client was not the initiator, play effect
        // otherwise we've already spawned and played it before sending the command
        if (NetworkPlayer.Local.netId != initiator)
        {
            EffectSpawner.Instance.SpawnAndPlay(pos);
            CameraShaker.Instance.ShakeMainCameraOnce(1.0f, 1.0f);
        }
    }
}
