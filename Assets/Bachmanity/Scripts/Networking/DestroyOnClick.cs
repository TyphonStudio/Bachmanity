using UnityEngine;
using UnityEngine.Networking;

public class DestroyOnClick : NetworkBehaviour {

    [ClientCallback]
    private void OnMouseDown()
    {
        // play effect instantly on local client
        EffectSpawner.Instance.SpawnAndPlay(transform.position);
        CameraShaker.Instance.ShakeMainCameraOnce(1.0f, 1.0f);

        // send destroy command to server
        NetworkPlayer.Local.Spawning.CmdDestroyWithEffect(netId, NetworkPlayer.Local.netId);
    }
}
