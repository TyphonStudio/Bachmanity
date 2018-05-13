using UnityEngine;
using UnityEngine.Networking;

public class NetworkMessengerModule : NetworkBehaviour {

    public static NetworkMessengerModule Local { get; private set; }

    public override void OnStartLocalPlayer()
    {
        Local = this;
    }

    [Command]
    public void CmdSendMessageToServer(string message)
    {
        Debug.Log("message recieved on server : " + message);
        RpcSendMessageToClients(message);
    }

    [ClientRpc]
    private void RpcSendMessageToClients(string message)
    {
        Debug.Log("message recieved on clients : " + message);
    }
}
