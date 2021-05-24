using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Player player = GameManager.GetPlayer(other.gameObject.name);
        player.transform.position = new Vector3(0, 2, 0);
        //player.GetComponent<RigidBody>.constraints = RigidbodyConstraints.FreezeAll;
    }
}
