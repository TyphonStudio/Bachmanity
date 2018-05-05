using UnityEngine.Networking;

public class DestroyOnClick : NetworkBehaviour {

    [Client]
    private void OnMouseDown()
    {
        // find a local player and send destroy command to server through it
        NetworkSpawningModule.Local.CmdDestroyOnServer(netId);
    }
}
