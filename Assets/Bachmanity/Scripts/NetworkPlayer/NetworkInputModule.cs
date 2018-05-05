using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkMessengerModule))]
[RequireComponent(typeof(NetworkPlayer))]
public class NetworkInputModule : NetworkBehaviour {

    public static NetworkInputModule Local { get; private set; }

    public override void OnStartLocalPlayer()
    {
        Local = this;
    }

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        // input is processed for local player only
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // send command from messenger module
            NetworkMessengerModule.Local.CmdSendMessageToServer("player " + netId + " says hi!");
        }

        if(Input.GetMouseButtonDown(1))
        {
            // send command from player
            NetworkSpawningModule.Local.CmdSpawnBarrelOnServer();
        }
    }
}
