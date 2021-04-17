using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Player player = GameManager.GetPlayer(other.gameObject.name);
        player.TakeDamage(100f);
    }
}
