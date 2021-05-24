using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;
    private bool coroutineAllowed;
    private int finalAngle;

    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(coroutineAllowed)
        {
            StartCoroutine(Spin());
        }
    }

    private IEnumerator Spin()
    {
        coroutineAllowed = false;
        randomValue = Random.Range(20, 30);
        timeInterval = 0.1f;

        for(int i = 0; i < randomValue; i++)
        {
            transform.Rotate(0, 0, 12.5f);
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.2f;
            if (i > Mathf.RoundToInt(randomValue * 0.85f))
                timeInterval = 0.4f;
            yield return new WaitForSeconds(timeInterval);
        }

        if (Mathf.RoundToInt(transform.eulerAngles.z) % 25 != 0)
            transform.Rotate(0, 0, 12.5f);
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
        Debug.Log(finalAngle);
        switch (finalAngle)
        {
            case 0:
                Debug.Log("1");
                break;
            case 25:
                Debug.Log("2");
                break;
            case 50:
                Debug.Log("3");
                break;
            case 75:
                Debug.Log("4");
                break;
            case 100:
                Debug.Log("5");
                break;
            case 125:
                Debug.Log("6");
                break;
            case 150:
                Debug.Log("7");
                break;
            case 175:
                Debug.Log("8");
                break;
            case 200:
                Debug.Log("9");
                break;
            case 225:
                Debug.Log("10");
                break;
            case 250:
                Debug.Log("11");
                break;
            case 275:
                Debug.Log("12");
                break;
            case 300:
                Debug.Log("13");
                break;
            case 325:
                Debug.Log("14");
                break;
            case 350:
                Debug.Log("1");
                break;
        }
        coroutineAllowed = false;
    }
}
