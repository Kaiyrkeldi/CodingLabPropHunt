using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class AudioSync : NetworkBehaviour
{
    private AudioSource source;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();

    }

    public void PlaySound(int id)
    {
        if(id >= 0 && id < clips.Length)
        {
            CmdSendSeverSoundID(id);
        }
    }

    [Command]
    void CmdSendSeverSoundID(int id)
    {
        RpcSendSoundIDToClients(id);
    }

    [ClientRpc]
    void RpcSendSoundIDToClients(int id)
    {
        source.PlayOneShot(clips[id]);
    }
}
