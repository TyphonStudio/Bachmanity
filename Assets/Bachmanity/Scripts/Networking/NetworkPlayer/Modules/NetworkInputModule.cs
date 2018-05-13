using UnityEngine;
using UnityEngine.Networking;

public class NetworkInputModule : NetworkBehaviour {

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (!isLocalPlayer)
            return;

        if(Input.GetMouseButtonDown(1))
        {
            NetworkPlayer.Local.Spawning.CmdSpawnBarrelOnServer();
        }
    }
}
