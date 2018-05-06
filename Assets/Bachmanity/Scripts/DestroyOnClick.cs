using UnityEngine;
using UnityEngine.Networking;

public class DestroyOnClick : NetworkBehaviour {

    [ClientCallback]
    private void OnMouseDown()
    {
        // play effect instantly on local client
        EffectSpawner.Instance.SpawnAndPlay(transform.position);
        
        // send destroy command to server
        NetworkSpawningModule.Local.CmdDestroyWithEffect(netId, NetworkPlayer.Local.netId);
    }
}
