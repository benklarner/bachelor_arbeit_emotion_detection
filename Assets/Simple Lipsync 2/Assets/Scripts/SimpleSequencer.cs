///-----------------------------------------------------------------
///   Class:          ExampleSequencer
///   Author:         Noir                    Date: 26/11/2018
///   Website:        ShadowNoir.com
///-----------------------------------------------------------------
///

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SequenceMan
{
    //name of character
    public string CharacterName = "Unknown";
    
    //the ID of audio will be played
    public int audioID = 0;

    //Should wait till the audio is completed
    public bool WaitForAudioEnd = true;

    //the current audio in queue
    [HideInInspector]
    public int currentID = 0;
}

[AddComponentMenu("Noir Project/Simple LipSync 2/LipSync Simple Sequencer")]
public class SimpleSequencer : MonoBehaviour {

    public float preDelay = 0.0f;
    
    private SimpleLipsyncMain lipsync = null;
    public bool playOnAwake = true;
    public SequenceMan[] sequenceManager = null;

	// Use this for initialization
	void Start () 
    {
        //find when the lipsysnc manager transform in the scene is not set by the user
        lipsync = (SimpleLipsyncMain) FindObjectOfType<SimpleLipsyncMain>();

        if (playOnAwake)
            StartCoroutine(SceneSequence());
	}

    

    public IEnumerator SceneSequence()
    {
        //Just hold on few seconds before start the scene
        yield return new WaitForSeconds(preDelay);

        //The Sequence is set and lipsync is available
        if (sequenceManager.Length > 0 && lipsync != null)
        {
            //check the sound queue
            foreach (SequenceMan sm in sequenceManager)
            {
                //if the character is available
                if (lipsync.getCharacterByName(sm.CharacterName) != null)
                {
                    //play the sound sequence
                    playSequence(sm.CharacterName, sm.audioID);

                    //check if should wait for audio ends
                    if (sm.WaitForAudioEnd)
                    {
                        //wait for the audio lenght time
                        yield return new WaitForSeconds(lipsync.getSequenceLenght(sm.CharacterName, sm.audioID));
                    }
                }
                yield return null;
            }
        }
        yield return null;
    }


	public void playSequence(string name, int id)
    {
        if (lipsync != null)
        {
            lipsync.playSequendByAudioID(name, id);
        }
        else
        {
            Debug.Log("Please define the Lipsync Component on the scene.");
        }
    }



	// Update is called once per frame
	void Update () {
		
	}
}
