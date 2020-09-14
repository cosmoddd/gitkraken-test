using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LightControlTest : NetworkBehaviour
{
    public Light thisLight;
    public bool keyOverride;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && keyOverride == true)
        {
            RpcLightToggle();
        }
    }

    // [Command(ignoreAuthority = true)]
    [ClientRpc]
    void RpcLightToggle()
    {
        thisLight.enabled = !thisLight.enabled;
    }
}
