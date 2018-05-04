using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkMessenger))]
public class NetworkPlayerInput : NetworkBehaviour {

    NetworkMessenger networkMessenger;

    private void Awake()
    {
        networkMessenger = GetComponent<NetworkMessenger>();
    }

    private void Update()
    {
        DoInput();
    }

    private void DoInput()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            networkMessenger.CmdSendMessageToServer("player " + netId + " says hi!");
        }
    }
}
