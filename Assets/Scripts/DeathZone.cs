using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Player player = GameManager.GetPlayer(other.gameObject.name);
        player.GetComponent<Rigidbody>().transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, 0);
    }
}
