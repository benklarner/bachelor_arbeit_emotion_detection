using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.UI;


/*
 * handles the UI input and communicates with the audio manager
 */


[RequireComponent(typeof(AudioSource))]
public class Controller : MonoBehaviour//NetworkBehaviour

{
    public Slider pitchSlider;
    public Slider scaleSlider;
    public Slider camSlider;
    public Slider volSlider;
    private Dropdown dropdown;

    private AudioManager audioManager;

    
    private float loopDelay = 0;
    
    private bool autoPlay = false;
   
    private float agentVol = -1;
    
    public float agentPitch = 1;
   
    private Vector3 agentScale = new Vector3(-0.1F, -0.1F, -0.1F);
   
    private Vector3 agentPos = new Vector3(-0.1F, -0.1F, -0.1F);
   
    private Quaternion agentTilt = Quaternion.Euler(-0.1F, 0, 0);
    
   /*
    * if counterbalanced feedback is wanted, the user can get instructions via the console
    * on which reaction to perform next. The involved code can be ignored when one is not
    * interested in the counterbalacing. This is marked with a "for experiment"-Comment
    */
    private int playCount = 0;
    private string[] latinsqr = new string[] { "scale", "move cam", "pitch", "move cam", "pitch", "scale", "pitch", "scale", "move cam" };
    private int instructionIndex = 0;

    void Start()
    {
        //for experiment
        instructionIndex = UnityEngine.Random.Range(0, latinsqr.Length);

        audioManager = GetComponent<AudioManager>();

        InitServerUI();

        //If-Clause in case the therapist already made changes
        if (agentScale.Equals(new Vector3(-0.1F, -0.1F, -0.1F))) { agentScale = this.transform.localScale; agentTilt = this.transform.localRotation; }
        if (agentPos.Equals(new Vector3(-0.1F, -0.1F, -0.1F))) { agentPos = this.transform.localPosition; }
        if (agentVol == -1) { agentVol = audioManager.GetVolume();}

        ScaleAgent();
        MoveAgent();
        SetVolume();
        audioManager.UpdatePitch(agentPitch);


    }
    // updates the state of the agent
    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, agentScale, 0.1f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, agentPos, 0.1f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, agentTilt, 0.1f);
        audioManager.UpdatePitch(agentPitch);
        audioManager.UpdateVolume(agentVol);


        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            audioManager.OnTrackChosen(0);
            OnPlayPressed();
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            audioManager.OnTrackChosen(1);
            OnPlayPressed();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            audioManager.OnTrackChosen(2);
            OnPlayPressed();
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            audioManager.OnTrackChosen(3);
            OnPlayPressed();
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            audioManager.OnTrackChosen(4);
            OnPlayPressed();
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            audioManager.OnTrackChosen(5);
            OnPlayPressed();
        }
    }

    // initializes the UI elements und sets  listeners
    void InitServerUI()
    {
        //if (!isServer) { return; }
        scaleSlider = GameObject.Find("Slider_Scale").GetComponent<Slider>();
        scaleSlider.onValueChanged.AddListener(delegate { ScaleAgent(); });

        pitchSlider = GameObject.Find("Slider_Pitch").GetComponent<Slider>();
        pitchSlider.onValueChanged.AddListener(delegate { PitchAgent(); });

        camSlider = GameObject.Find("Slider_Cam").GetComponent<Slider>();
        camSlider.onValueChanged.AddListener(delegate { MoveAgent(); });

        volSlider = GameObject.Find("Slider_Vol").GetComponent<Slider>();
        volSlider.onValueChanged.AddListener(delegate { SetVolume(); });

        Button playButton = GameObject.Find("Button_Play").GetComponent<Button>();
        playButton.onClick.AddListener(OnPlayPressed);

        Button nextButton = GameObject.Find("Button_Forward").GetComponent<Button>();
        nextButton.onClick.AddListener(CmdSendNext);

        Button backButton = GameObject.Find("Button_Back").GetComponent<Button>();
        backButton.onClick.AddListener(CmdSendPrev);

        GameObject loopButtonObj = GameObject.Find("Button_Loop");
        Button loopButton = loopButtonObj.GetComponent<Button>();
        loopButton.onClick.AddListener(delegate { OnLoopPressed(loopButtonObj); });

        InputField delayInput = GameObject.Find("InputField_Delay").GetComponent<InputField>();
        delayInput.onEndEdit.AddListener(OnDelaySet);

        StartCoroutine("SetUpDropDown");

    }

    // sets the audio dropdown menu up when all files are loaded
    IEnumerator SetUpDropDown()
    {
        while (!audioManager.GetIsReady())
        {
            yield return new WaitForSeconds(0.2f);
        }

        dropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        dropdown.ClearOptions();
        dropdown.AddOptions(audioManager.GetFileNames());
        dropdown.value = audioManager.GetCurrentFileIndex();
        dropdown.onValueChanged.AddListener(delegate
        {
            CmdSendTrackChoice(dropdown.value);
        });
        CmdSendTrackChoice(dropdown.value);
    }

    void DropdownValueChanged(Dropdown dropdown) { audioManager.OnTrackChosen(dropdown.value); }
    void ScaleAgent()
    {
        //if (!isServer) { return; }
        agentScale = new Vector3(scaleSlider.value, scaleSlider.value, scaleSlider.value);
    }
    void PitchAgent()
    {
       // if (!isServer) { return; }
        agentPitch = (-1) * pitchSlider.value;
    }

    void MoveAgent()
    {
        //if (!isServer) { return; }
        agentPos = new Vector3(this.transform.localPosition.x, camSlider.value, this.transform.localPosition.z);
        agentTilt = Quaternion.Euler(camSlider.value * 3, 0, 0);
    }

    void SetVolume()
    {
        //if (!isServer) { return; }
        agentVol = volSlider.value;
    }

    void OnPlayPressed()
    {
       // if (!isServer) { return; }
        CmdSendPlayAudio();

    }

    void OnLoopPressed(GameObject btn)
    {

      //  if (!isServer) { return; }
        autoPlay = !autoPlay;
        if (autoPlay)
        {
            btn.GetComponent<Image>().color = Color.magenta;
        }
        else
        {
            btn.GetComponent<Image>().color = Color.white;
        }
    }

    void UpdateDropdown() {dropdown.value = audioManager.GetCurrentFileIndex(); }

    void OnDelaySet(string input)
    {
        int number;
        if (int.TryParse(input, out number))
        {
            loopDelay = number;
        }


    }

    private IEnumerator waitForSoundFinished()
    {
        while (audioManager.GetIsPlaying())
        {
            yield return null;
        }
        ReplayClip();
    }

    private void ReplayClip()
    {
        if (autoPlay)
        {
            OnPlayPressed();
        }

    }
    //for experiment
    private void NextInstruction()
    {
        if (instructionIndex < latinsqr.Length - 1)
        {
            instructionIndex++;
        }
        else { instructionIndex = 0; }

    }


    void CmdSendNext() { RpcOnNext(); }

    void RpcOnNext()
    {
        audioManager.OnNext();
        UpdateDropdown();
    }


    void CmdSendPrev() { RpcOnBack(); }

    void RpcOnBack()
    {
        audioManager.OnBack();
        UpdateDropdown();
    }


    void CmdSendTrackChoice(int ddVal) { RpcOnDropdown(ddVal); }

    void RpcOnDropdown(int ddVal)
    {
        audioManager.OnTrackChosen(ddVal);
    }


    void CmdSendPlayAudio()
    {
        RpcPlayAudio();
    }

    void RpcPlayAudio()
    {
        //for experiment
        playCount++;
        NextInstruction();
        print("Played " + playCount + "/30. Now " + latinsqr[instructionIndex] + "!"); ;

        float delay;
        if (!autoPlay) { delay = 0; } else { delay = loopDelay; }

        audioManager.OnPlayAudio(delay);
  
    }
}


