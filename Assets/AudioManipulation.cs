using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManipulation : MonoBehaviour
{
    public AudioSource _AudioSource;
    public GameObject _SliderPitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _AudioSource.pitch = _SliderPitch.GetComponent<Slider>().value;//GameObject.Find("SliderPitch").GetComponent<Slider>().value;
    }
}
