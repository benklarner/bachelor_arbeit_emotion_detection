/*
 * Copyright 2017 Open University of the Netherlands (OUNL)
 *
 * Authors: Kiavash Bahreini, Wim van der Vegt.
 * Organization: Open University of the Netherlands (OUNL).
 * Project: The RAGE project
 * Project URL: http://rageproject.eu.
 * Task: T2.3 of the RAGE project; Development of assets for emotion detection. 
 * 
 * For any questions please contact: 
 *
 * Kiavash Bahreini via kiavash.bahreini [AT] ou [DOT] nl
 * and/or
 * Wim van der Vegt via wim.vandervegt [AT] ou [DOT] nl
 *
 * Cite this work as:
 * Bahreini, K., van der Vegt, W. & Westera, W. Multimedia Tools and Applications (2019). https://doi.org/10.1007/s11042-019-7250-z
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * This project has received funding from the European Union’s Horizon
 * 2020 research and innovation programme under grant agreement No 644187.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using AssetPackage;
using UnityEditor;
using System.Text;
using System.Collections;



//public class WebGLEditorScript
//{
//    [MenuItem("WebGL/Enable Embedded Resources")]
//    public static void EnableEmbeddedResources()
//    {
//        PlayerSettings.SetPropertyBool("useEmbeddedResources", true, BuildTargetGroup.WebGL);
//    }
//}

public class ButtonScript : MonoBehaviour
{

    IEnumerator CameraPermission()
    {
        findWebCams();

        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
          Debug.Log("webcam found");
        }
        else
      {
            Debug.Log("webcam not found");
        }
    }
   void findWebCams()
    {
     foreach (var device in WebCamTexture.devices)
     {
          Debug.Log("Name: " + device.name);
        }
    }


    //! http://answers.unity3d.com/questions/909967/getting-a-web-cam-to-play-on-ui-texture-image.html

    /// <summary>
    /// The rawimage, used to show webcam output.  
    /// </summary>
    ///
    /// <remarks>
    /// In this demo, rawimage is the Canvas of the scene.
    /// </remarks>
    public RawImage rawimage;

    /// <summary>
    /// The emotions, used to show the detedted emotions.
    /// </summary>
    ///
    /// <remarks>
    /// In this demo, emotions is the bottom Text object of the scene.
    /// </remarks>
    public Text emotions;

    /// <summary>
    /// The message, used to signal the number of faces detected.
    /// </summary>
    /// 
    /// <remarks>
    /// In this demo, emotions is the top Text object of the scene.
    /// </remarks>
    public Text msg;

    //! https://answers.unity3d.com/questions/1101792/how-to-post-process-a-webcamtexture-in-realtime.html

    /// <summary>
    /// The webcam.
    /// </summary>
    WebCamTexture webcam;

    /// <summary>
    /// The output.
    /// </summary>
    Texture2D output;

    /// <summary>
    /// The data.
    /// </summary>
    Color32[] data;


    /// <summary>
    /// Use this for initialization.
    /// </summary>
    /// 
    GameObject playBTN;
    Toggle toggle;

    public int csvHeader = 0;
    public double timer;
    public ExperimentLogic experimentLogic;
    public WriteToFile writeToFile;


    
void Start()
    {
        //1) Enumerate webcams
        //
        WebCamDevice[] devices = WebCamTexture.devices;


        //2) for debugging purposes, prints available devices to the console
        //
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }

        //! http://answers.unity3d.com/questions/909967/getting-a-web-cam-to-play-on-ui-texture-image.html
        //WebCamTexture webcam = new WebCamTexture();
        //rawimage.texture = webcam;
        //rawimage.material.mainTexture = webcam;
        //webcamTexture.Play();

        //! https://answers.unity3d.com/questions/1101792/how-to-post-process-a-webcamtexture-in-realtime.html
        //3) Create a WebCamTexture (size should not be to big)
        webcam = new WebCamTexture(640, 480);
     
        //4) Assign the texture to an image in the UI to see output (these two lines are not necceasary if you do 
        //   not want to show the webcam video, but might be handy for debugging purposes)
        rawimage.texture = webcam;
        rawimage.material.mainTexture = webcam;
   

        //5) Start capturing the webcam.
        //
        webcam.Play();

        //6) ??
        //output = new Texture2D(webcam.width, webcam.height);
        //GetComponent<Renderer>().material.mainTexture = output;

        // 7) Create an array to hold the ARGB data of a webcam video frame texture. 
        //
        data = new Color32[webcam.width * webcam.height];

        //8) Create an EmotionDetectionAsset
        //
        //   The asset will load the appropriate dlibwrapper depending on process and OS.
        //   Note that during development unity tends to use the 32 bits version where 
        //   during playing it uses either 32 or 64 bits version dependend on the OS.
        //   
        eda = new EmotionDetectionAsset();

        //9) Assign a bridge (no interfaces are required but ILog is convenient during development.
        // 
        eda.Bridge = new dlib_csharp.Bridge();

        //10) Init the EmotionDetectionAsset. 
        //    Note this takes a couple of seconds as it need to read/parse the shape_predictor_68_face_landmarks database
        //
        
       //For Standalone Build
       eda.Initialize(@"Experiment_Data\Plugins", database);


        //For Editor
        //eda.Initialize(@"Assets/FER/", database);
        //dlopen error


        //11) Read the fuzzy logic rules and parse them.
        // 
        //WebGL Path error
        String[] lines = File.ReadAllLines(furia);
        eda.ParseRules(lines);

        Debug.Log("Emotion detection Ready for Use");

        toggle = GameObject.Find("WiedersprochenToggle").GetComponent<Toggle>();

        playBTN = GameObject.Find("PlayButton");

        toggle.onValueChanged.AddListener(delegate { });

        //InvokeRepeating("LogEmotions", 4.0f, 3.0f);

    }



Int32 frames = 0;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        if (playBTN.activeSelf == false)
        {
            webcam.Play();
            timer += Time.deltaTime;
          
            if (data != null && eda != null && (++frames) % 15 == 0)
            {
                // 2) Get the raw 32 bits ARGB data from the frame.
                // 
                webcam.GetPixels32(data);
                // 3) Process this ARGB Data.
                // 
                ProcessColor32(data, webcam.width, webcam.height);
                frames = 0;
            }
        }
        if (toggle.isOn)
        {
            webcam.Stop();
            csvHeader = 0;
            timer = 0;
        }
      
    }

    public void detectFaces()
    {
       
    }


    /// <summary>
    /// A face (test input).
    /// </summary>
    const String face3 = @"AssetsFER/Kiavash1.jpg";

    /// <summary>
    /// The Furia Fuzzy Logic Rules.
    /// </summary>
    //TextAsset furiaData = (TextAsset)Resources.Load("FURIA Fuzzy Logic Rules");
    string furia = @"Experiment_Data/Resources/FURIA Fuzzy Logic Rules.txt";

    /// <summary>
    /// The landmark database.
    /// </summary>
    const String database = @"Experiment_Data/Resources/shape_predictor_68_face_landmarks.dat";

    /// <summary>
    /// http://ericeastwood.com/blog/17/unity-and-dlls-c-managed-and-c-unmanaged
    /// https://docs.unity3d.com/Manual/NativePluginInterface.html.
    /// </summary>
    EmotionDetectionAsset eda;


    /// <summary>
    /// Color32 array to byte array.
    /// </summary>
    ///
    /// <param name="colors"> The colors. </param>
    ///
    /// <returns>
    /// A byte[].
    /// </returns>
    private static byte[] Color32ArrayToByteArray(UnityEngine.Color32[] colors)
    {
        if (colors == null || colors.Length == 0)
            return null;

        int lengthOfColor32 = Marshal.SizeOf(typeof(UnityEngine.Color32));
        int length = lengthOfColor32 * colors.Length;
        byte[] bytes = new byte[length];

        GCHandle handle = default(GCHandle);
        try
        {
            handle = GCHandle.Alloc(colors, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();
            Marshal.Copy(ptr, bytes, 0, length);
        }
        finally
        {
            if (handle != default(GCHandle))
                handle.Free();
        }

        return bytes;
    }

   
    /// <remarks>
    /// This method is used to process raw data from Unity webcam frame textures.
    /// </remarks>
    ///
    /// <param name="pixels"> The pixels. </param>
    /// <param name="width">  The width. </param>
    /// <param name="height"> The height. </param>
    private void ProcessColor32(Color32[] pixels, Int32 width, Int32 height)
    {
        // Convert raw ARGB data into a byte array.
        byte[] raw = Color32ArrayToByteArray(pixels);
        // Try to detect faces. This is the most time consuming part.
        // Note there the formats supported are limited to 24 and 32 bits RGB at the moment.
        if (eda.ProcessImage(raw, width, height, true))
        {
            msg.text = String.Format("{0} Face(s detected.", eda.Faces.Count);
            // Process each detected face by detecting the 68 landmarks in each face
            // 
            if (eda.ProcessFaces())
            {
                // Process landmarks into emotions using fuzzy logic.
                // 
                if (eda.ProcessLandmarks())
                {// Extract results.
                    Dictionary<string, string> emotionsDictionary = new Dictionary<string, string>();
                    foreach (String emo in eda.Emotions)
                    {
                        // Extract (averaged) emotions of the first face only.
                        emotionsDictionary[emo] = eda[0, emo].ToString();
                    }
                    //Create the emotion strings.
                    emotionsDictionary.Add("Time", timer.ToString());
                    emotionsDictionary.Add("Run",  experimentLogic.Run.ToString());
                    emotionsDictionary.Add("Code", PlayerPrefs.GetString("Code"));
                    emotionsDictionary.Add("Studiencode", PlayerPrefs.GetString("Studiencode"));
                    emotionsDictionary.Add("Mode", PlayerPrefs.GetString("Mode"));
                    emotionsDictionary.Add("Date", System.DateTime.UtcNow.ToString());

                    emotions.text = String.Join("\r\n", emotionsDictionary.OrderBy(p => p.Key).Select(p => String.Format("{0}={1:0.00}", p.Key, p.Value)).ToArray());
                    PlayerPrefs.SetString("EmotionData", String.Join(";", emotionsDictionary.Values.ToArray()));
                    writeToFile.sendEmotionData();
                }
                else {emotions.text = "No emotions detected";}
            }
            else{emotions.text = "No landmarks detected";}
        }
        else{msg.text = "No Face(s) detected";}
    }


    //void LogEmotions()
    //{
    //    Debug.Log(emotions.text);
    //    Debug.Log(msg);
    //}
}
