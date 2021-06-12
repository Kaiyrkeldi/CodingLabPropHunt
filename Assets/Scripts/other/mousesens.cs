using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mousesens : MonoBehaviour
{
    public float sensp;

    public void setsens(float sens)

    {
        
       sensp = sens;
       PlayerPrefs.SetFloat("sensvalue", sensp);
    }
}
