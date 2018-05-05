using UnityEngine;
using UnityEngine.Networking;

public class DestroyOnClick : NetworkBehaviour {

    [Client]
    private void OnMouseDown()
    {
        // better spawn the effect object, put it where the barrel is, enable, play and disable/destroy in the end
        // play effect on local client
        // destroyEffect.PlayEffect();
        
        // find a local player and send destroy command to server through it
        NetworkSpawningModule.Local.CmdDestroyWithEffect(netId);
    }

    private void OnDestroy()
    {
        EffectSpawner.Instance.SpawnAndPlay((transform.position));
    }
}
