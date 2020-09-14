using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkSetupCMD : NetworkManager
{
    [Header("Settings")]
    public string charName;
    public int charInt;

    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<SendPlayerMessage>(DoItUp);

    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        SendPlayerMessage theMessage = new SendPlayerMessage();
        theMessage.thisName = charName;
        theMessage.madness = charInt;

        conn.Send(theMessage);
    }

    void DoItUp(NetworkConnection connection, SendPlayerMessage m)
    {

        GameObject player = Instantiate(playerPrefab);  
        Mirror.Examples.Basic.Player p = player.GetComponent<Mirror.Examples.Basic.Player>();
        p.zamZam = m.thisName;
        p.playerNameText.text = p.zamZam;
        p.waddadaa = m.madness;

        NetworkServer.AddPlayerForConnection(connection, player);
        print("YOOO");
    }

}


