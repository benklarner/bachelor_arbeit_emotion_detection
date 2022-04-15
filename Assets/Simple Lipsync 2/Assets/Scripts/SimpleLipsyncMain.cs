///-----------------------------------------------------------------
///   Class:          SimpleLipsyncMain
///   Author:         Noir                    Date: 26/11/2018
///   Website:        ShadowNoir.com
///-----------------------------------------------------------------
///

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FakeMover
{
    //What is fakeMover? The random pulse generator can animate mouth without sound

    //The indicator for fake mover
    public bool isFakeMove = false;
    
    //Delay Between Each Pulse
    [Range (0.01f, 0.05f)]
    public float PulseDelay = 0.03f;

    //Deley before first pulse
    public float StartDelay = 0.0f;

    public string[] CharacterNames = null;
}

[Serializable]
public class LipSyncAudioLines
{
    //The audio ID will use further for playing the desired sequence
    public int AudioID = 0;

    //Audio Sense Volume
    public float MotionSense = 0.50f;

    //Audio Line
    public AudioClip Dialogue = null;

    //Play the audio on awake
    public bool playOnAwake = false;

    //The delay before playing the audio line
    public float playDelaySeconds = 0.0f;
}

[Serializable]
public class LipSyncCharacter
{
    public string CharacterName = "Unknown";

    //Types of position changes
    public enum DirAxis
    {
        XAxis,
        YAxis,
        ZAxis
    }

    //Setup the position Axis
    public DirAxis DirectionAxis = DirAxis.XAxis;

    public enum DirectionType
    {
        Straight,
        Inverse
    }

    //Setting up direction selector
    public DirectionType directionType = DirectionType.Straight;


    public LipSyncJawProperty JawProperty = null;
    public LipSyncAudioLines[] Dialogues = null;
    
    

    [HideInInspector]
    public AudioSource cAudio = null;

    [HideInInspector]
    public LipSyncCharacter cCharacter = null;

    [HideInInspector]
    public LipSyncAudioLines cLine = null;

}

[Serializable]
public class LipSyncJawProperty
{
    //The Desired Character Jawbone
    public Transform JawBone = null;

    //Speed of closing the mouth
    public float jawFeedback = 3.5f;

    //maximum distance that jaw can travel ;)
    public float maxMouthPosition = 0.05f;

    //current distance from default
    public float currentMouthValue = 0.0f; // Readonly Value

    [HideInInspector]
    public Vector3 defaultJawPosition = Vector3.zero;
}

[AddComponentMenu("Noir Project/Simple LipSync 2/LipSync Manager")]
public class SimpleLipsyncMain : MonoBehaviour 
{
    //Initite the fake mover for further use
    public FakeMover fakeMoverControl = null;

    //Character Definition based on above Character class
    public LipSyncCharacter[] Characters = null;

    //Sound to Animate Values
    private float sum = 0.0f;
    private float rms = 0.0f;
    private float scale = 0.0f;
    private int nsamples = 1024;
    private int freqMax = 24000;
    private float LowF = 200;
    private float HighF = 400;

    private float[] samples;

    //Animation Filter System Values
    private int filterSize = 32;
    private float[] filter;
    private float fSummary;
    private int filterPosition = 0;
    private int SamplesSmooth = 0;

    //This will add Audiosources on jaw bone of all of the available characters
    public void addAudioSources()
    {
        //Check when characters are defined
        if (Characters.Length > 0)
        {
            //Get all of the characters
            foreach (LipSyncCharacter lc in Characters)
            {
                //if the 1 or more dialogue is set on the character
                //we will add an audio source on jaw bone of that character
                if (lc.Dialogues.Length > 0)
                {
                    //when the jaw is defined for character
                    if (lc.JawProperty.JawBone != null)
                    {
                        //check for audio source availablity there
                        if (lc.JawProperty.JawBone.GetComponent<AudioSource>() == null)
                        {
                            lc.JawProperty.JawBone.gameObject.AddComponent<AudioSource>();
                        }
                    }
                }
            }
        }
    }

    //Filter noises and return smooth value
    public float SmoothMove(float sampleRate)
    {
        if (SamplesSmooth == 0)
            filter = new float[filterSize];

        fSummary += sampleRate - filter[filterPosition];
        filter[filterPosition++] = sampleRate;

        if (filterPosition > SamplesSmooth)
            SamplesSmooth = filterPosition;

        filterPosition = filterPosition % filterSize;

        return (sampleRate / SamplesSmooth);
    }

    //Find the character by name and play the Dialogue Sequence 
    public void playSequendByAudioID(String CharacterName, int AudioID)
    {
        LipSyncCharacter currentCharacter = null;
        AudioSource currentAudioSource = null;
        LipSyncAudioLines currentLine = null;

        //Find the Desired Character and then set on the currentCharacter
        //Check when characters are defined
        if (Characters.Length > 0)
        {
            //Get all of the characters and then define the desired
            foreach (LipSyncCharacter lc in Characters)
            {
                //When the character name is founded
                if (lc.CharacterName.Equals(CharacterName))
                {
                    currentCharacter = lc;
                }
            }

            //check when the current character is set
            if (currentCharacter != null)
            {
                //find the audio clip
                //check if the character has dialogues
                if (currentCharacter.Dialogues.Length > 0)
                {
                    //Search the audio lines of the desired character
                    foreach (LipSyncAudioLines aud in currentCharacter.Dialogues)
                    {
                        //check for audio ID [ID Duplication cause false value, Each character should have unique audio IDs]
                        if (aud.AudioID == AudioID)
                        {
                            //set the current clip when found by ID
                            currentLine = aud;
                        }
                    }
                }
            }
        }

        //When the jawbone is found for the current character
        if (currentCharacter.JawProperty.JawBone != null)
        {
            //check if audio source is available
            if (currentCharacter.JawProperty.JawBone.GetComponent<AudioSource>() != null)
            {
                //set the current audiosource
                currentAudioSource = currentCharacter.JawProperty.JawBone.GetComponent<AudioSource>();
            }
            //the audio source not found but the jawbone is set [just for sure we double check that]
            else 
            {
                //so add a new audio source on jaw bone
                currentCharacter.JawProperty.JawBone.gameObject.AddComponent<AudioSource>();

                //and then define as a current audio source
                currentAudioSource = currentCharacter.JawProperty.JawBone.GetComponent<AudioSource>();
            }
        }

        currentCharacter.cAudio = currentAudioSource;
        currentCharacter.cCharacter = currentCharacter;
        currentCharacter.cLine = currentLine;

        currentAudioSource.clip = currentLine.Dialogue;
        currentAudioSource.Play();
    }

    public void GetAudioClipData(LipSyncAudioLines audLine, LipSyncCharacter character, AudioSource audios)
    {
        if (audios == null)
            return;

        float freqLow = Mathf.Clamp(LowF, 20, freqMax);
        float freqHigh = Mathf.Clamp(HighF, freqLow, freqMax);

        samples = new float[nsamples];
        audios.GetOutputData(samples, 0);

        int t1 = (int)Mathf.Floor(freqLow * nsamples / freqMax);
        int t2 = (int)Mathf.Floor(freqHigh * nsamples / freqMax);

        float sum = 0;

        for (int i = t1; i <= t2; i++)
        {
            sum += samples[i] * audLine.MotionSense;
        }

        sum = sum / (t2 - t1 + 1);

        float Value = (character.JawProperty.JawBone.transform.localPosition.x) + SmoothMove(sum);

        //Animate the jaw by the value from audio
        AnimateByValue(character, Value, sum);
    }

    public void AnimateByValue(LipSyncCharacter character, float value, float sum)
    {
        //when character has a jaw
        if (character.JawProperty.JawBone != null)
        {
            character.JawProperty.currentMouthValue = value;

            if (character.JawProperty.currentMouthValue > character.JawProperty.maxMouthPosition)
            {
                character.JawProperty.currentMouthValue = character.JawProperty.maxMouthPosition;
            }

            //Update value to filter limitation
            value = character.JawProperty.currentMouthValue;

            //start when talking
            if (sum >= 0.01f)
            {
                //Check if its inversed
                if (character.directionType == LipSyncCharacter.DirectionType.Inverse)
                {
                    value *= -1;
                }

                //Check for Axis Direction and apply movement
                if (character.DirectionAxis == LipSyncCharacter.DirAxis.XAxis)
                {
                    character.JawProperty.JawBone.transform.localPosition = new Vector3(value, character.JawProperty.JawBone.transform.localPosition.y, character.JawProperty.JawBone.transform.localPosition.z);
                }
                if (character.DirectionAxis == LipSyncCharacter.DirAxis.YAxis)
                {
                    character.JawProperty.JawBone.transform.localPosition = new Vector3(character.JawProperty.JawBone.transform.localPosition.x, value, character.JawProperty.JawBone.transform.localPosition.z);
                }
                if (character.DirectionAxis == LipSyncCharacter.DirAxis.ZAxis)
                {
                    character.JawProperty.JawBone.transform.localPosition = new Vector3(character.JawProperty.JawBone.transform.localPosition.x, character.JawProperty.JawBone.transform.localPosition.y, value);
                }
            }
            else
            {
                //Force close the mouth
                if (character.DirectionAxis == LipSyncCharacter.DirAxis.XAxis)
                {
                    float closePos = Mathf.Lerp(character.JawProperty.JawBone.transform.localPosition.x, character.JawProperty.defaultJawPosition.x, character.JawProperty.jawFeedback * Time.deltaTime);
                    Vector3 newpos = new Vector3(closePos, character.JawProperty.defaultJawPosition.y, character.JawProperty.defaultJawPosition.z);
                    character.JawProperty.JawBone.transform.localPosition = newpos;
                }
                if (character.DirectionAxis == LipSyncCharacter.DirAxis.YAxis)
                {
                    float closePos = Mathf.Lerp(character.JawProperty.JawBone.transform.localPosition.y, character.JawProperty.defaultJawPosition.y, character.JawProperty.jawFeedback * Time.deltaTime);
                    Vector3 newpos = new Vector3(character.JawProperty.defaultJawPosition.x, closePos, character.JawProperty.defaultJawPosition.z);
                    character.JawProperty.JawBone.transform.localPosition = newpos;
                }
                if (character.DirectionAxis == LipSyncCharacter.DirAxis.ZAxis)
                {
                    float closePos = Mathf.Lerp(character.JawProperty.JawBone.transform.localPosition.z, character.JawProperty.defaultJawPosition.z, character.JawProperty.jawFeedback * Time.deltaTime);
                    Vector3 newpos = new Vector3(character.JawProperty.defaultJawPosition.x, character.JawProperty.defaultJawPosition.y, closePos);
                    character.JawProperty.JawBone.transform.localPosition = newpos;
                }
            }
            
        }
        else
        {
            //Jaw Definition error
            Debug.Log("SimpleLipsync2: Jaw for the character is not defined !");
        }
    }

    public LipSyncCharacter getCharacterByName(string name)
    {
        if (Characters.Length > 0)
        {
            foreach (LipSyncCharacter lc in Characters)
            {
                if (lc.CharacterName.Equals(name))
                {
                    return lc;
                }
            }
        }

        return null;
    }

    //This will generate pulses
    public IEnumerator FakeMover(bool delay)
    {
        if (delay)
            yield return new WaitForSeconds(fakeMoverControl.StartDelay);

        foreach (string s in fakeMoverControl.CharacterNames)
        {
            //Get the character from the name
            LipSyncCharacter ch = getCharacterByName(s);
            
            //check if the character is available
            if (ch != null) fakeMoverControl.isFakeMove = true;
            
            //generate Fake pulse
            FakeMoverGenerator(ch);
        }

        //For for pulse delay
        yield return new WaitForSeconds(fakeMoverControl.PulseDelay);

        //If allow to Fake move generate another pulse
        if (fakeMoverControl.isFakeMove)
        {
            StartCoroutine(FakeMover(false));
        }

        yield return null;
    }

    //This will generate random motion
    public void FakeMoverGenerator(LipSyncCharacter character)
    {
        //when fake delay is available
        if (fakeMoverControl.isFakeMove)
        {
            //generate random pulse in range of the character mouth
            float ran = UnityEngine.Random.Range(0.01f, character.JawProperty.maxMouthPosition);

            //simulate the pulse, if it is more than 0.01f it will be simulated
            AnimateByValue(character, ran, ran);
        }
    }

    public void StopFakeMove()
    {
        fakeMoverControl.isFakeMove = false;
    }

    //This will return the lenght of the audio clip
    public float getSequenceLenght(string name, int id)
    {
        //Check the total characters lenght to be more than one
        if (Characters.Length > 0)
        {
            //search for desired charater in available character array
            foreach (LipSyncCharacter lc in Characters)
            {
                //When found the name
                if (lc.CharacterName.Equals(name))
                {
                    //Check for the desired audio id
                    foreach (LipSyncAudioLines al in lc.Dialogues)
                    {
                        //when audio is ready
                        if (al.AudioID == id)
                        {
                            //and the clip isnt null
                            if (al.Dialogue != null)
                            {
                                //return the lenght
                                return al.Dialogue.length;
                            }
                        }
                    }
                }
            }
        }
        //or when anything bad happened return -1 so it means error
        return -1f;
    }

    public void setDefaultJawPositions()
    {
        //Check the total characters lenght to be more than one
        if (Characters.Length > 0)
        {
            foreach (LipSyncCharacter lc in Characters)
            {
                lc.JawProperty.defaultJawPosition = lc.JawProperty.JawBone.transform.localPosition;
            }
        }
    }

    //This will handle play on awake for each individual audio
    public void checkPlayAwake()
    {
        //check if characters are available
        if (Characters.Length > 0)
        {
            foreach (LipSyncCharacter lc in Characters)
            {
                //when the audios are available
                if (lc.Dialogues.Length > 0)
                {
                    foreach (LipSyncAudioLines al in lc.Dialogues)
                    {
                        //find the audios tagged by play on awake flag
                        if (al.playOnAwake)
                        {
                            //play the desired id
                            StartCoroutine(playOnAwakeDelayed(al.playDelaySeconds, lc, al));
                        }
                    }
                }
            }
        }
    }

    public IEnumerator playOnAwakeDelayed(float delay, LipSyncCharacter lc, LipSyncAudioLines al)
    {
        yield return new WaitForSeconds(delay);
        playSequendByAudioID(lc.CharacterName, al.AudioID);
        yield return null;
    }

	// Use this for initialization
	void Start () 
    {
        //Add Audio source on the jawbone of all available characters for talking
        addAudioSources();

        //Collect all default jaw positions
        setDefaultJawPositions();

        //Start the fake mover if it's enabled
        if (fakeMoverControl.isFakeMove)
        {
            StartCoroutine(FakeMover(true));
        }

        //Play the audios tagged for play on awake
        checkPlayAwake();
	}

    void LateUpdate()
    {
        //when characters are ready
        if (Characters.Length > 0)
        {
            //check who is talking
            foreach (LipSyncCharacter c in Characters)
            {
                GetAudioClipData(c.cLine, c.cCharacter, c.cAudio);
            }
        }
    }
}
