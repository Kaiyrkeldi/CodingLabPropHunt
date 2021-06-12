using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Nearest : NetworkBehaviour
{
    GameObject[] props;
    GameObject closest;
    public Text ProximityCheck;
    public string nearest;
    void Start()
    {
        ProximityCheck = GameObject.Find("GM").GetComponent<GameManager_References>().ProximityCheck.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        props = GameObject.FindGameObjectsWithTag("Prop");
        if (isLocalPlayer)
        {
            FindClosestProp();
        }
    }

    void FindClosestProp()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in props)
        {
            Vector3 diff = go.transform.position - position;
            float currDist = diff.sqrMagnitude;
            if (currDist < distance)
            {
                closest = go;
                distance = currDist;
            }
        }
        if (distance <= 50)
        {
            ProximityCheck.color = Color.red;
            ProximityCheck.text = "Hot";
        }
        else if (distance <= 150)
        {
            ProximityCheck.color = Color.yellow;
            ProximityCheck.text = "Warm";
        }
        else if (distance > 150 || distance == Mathf.Infinity)
        {
            ProximityCheck.color = new Color(65f, 105f, 225f, 1f);
            ProximityCheck.text = "Cold";
        }

    }
}
