using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkMessenger : NetworkBehaviour {

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
