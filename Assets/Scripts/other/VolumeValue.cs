using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    private AudioSource audioSrc;
    public float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        musicVolume = GameObject.Find("Slider").GetComponent<Slider>().value;
        audioSrc.volume = musicVolume;
    }

}
