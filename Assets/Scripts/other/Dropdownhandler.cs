using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdownhandler : MonoBehaviour
{
    void Start()
    {
        
    }
    PropMotor pm;
    public void InputMenu(int value)
    {
        if (value == 0) { Debug.Log(value);
        }

        if (value == 1) {
            PropMotor.wallHack = true;
            Debug.Log(value);
        }
        if (value == 2) Debug.Log(value);
        if (value == 3) Debug.Log(value);
        GameObject.Find("GM").GetComponent<GameManager_References>().Perks.SetActive(false);
    }
}
