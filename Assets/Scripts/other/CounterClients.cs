using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CounterClients : NetworkBehaviour
{
    [SyncVar]
    public int hunters = 0;
    public int props = 0;
    public int deadHunters = 0;
    public int deadProps = 0;

    [Command]
    public void CmdIncreaseHunters() => this.hunters++;
    [Command]
    public void CmdIncreaseProps() => this.props++;
    [Command]
    public void CmdIncreaseDeadHunters() => this.deadHunters++;
    [Command]
    public void CmdIncreaseDeadProps() => this.deadProps++;

    [Command]
    public void CmdResetAllCounters()
    {
        this.hunters = 0;
        this.props = 0;
        this.deadHunters = 0;
        this.deadProps = 0;
    }

}