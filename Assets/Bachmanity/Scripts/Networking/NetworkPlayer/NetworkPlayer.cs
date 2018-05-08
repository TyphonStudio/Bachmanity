using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {

    public static NetworkPlayer Local { get; private set; }

    private void Awake()
    {
        Debug.Log("awake");
    }

    public override void OnStartLocalPlayer()
    {
        Debug.Log("start local player");
        Local = this;
    }
}
