using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDetector : MonoBehaviour
{
    // Start is called before the first frame update

    WebCamTexture webcam;
    Color32[] data;


    void Start()
    {
        Debug.Log("Working");


        WebCamDevice[] devices = WebCamTexture.devices;

        //2) for debugging purposes, prints available devices to the console
        //
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }

        webcam = new WebCamTexture(640, 480);
        webcam.Play();

        data = new Color32[webcam.width * webcam.height];

        //eda = new EmotionDetectionAsset();



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void thisworks()
    {
        Debug.Log(data);
    }


}
