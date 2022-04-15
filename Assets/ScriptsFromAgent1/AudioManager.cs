using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.Networking;
using System.IO;

/*
 * Loads the the audio data and ensures that the right one is played
 */
public class AudioManager : MonoBehaviour {

    public AudioClip[] audioFiles;

    private List<AudioClip> audioList = new List<AudioClip>();
    private int filesChecked = 0;
    private bool dataLoaded = false;
    
   // [SyncVar]
    public int currentFileIndex=0;

    public AudioSource audioSource;
    private bool autoplay = false;

 /*
  * In the beginning default files are loaded from the resources folder. 
  * This is prevent issues, if corrupted files are streamed by the user
  * The default files get overwritten by the ones from the StreamingAssets folder 
  */

    void Start () {
   
        //audioSource = GetComponent<AudioSource>();
        audioFiles = Resources.LoadAll<AudioClip>("Audioclips") ;
        
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        FileInfo[] allFiles = directoryInfo.GetFiles("*.*");
        
        var index = 0;
        foreach (FileInfo file in allFiles)

        {
            index++;
            StartCoroutine(LoadAudioFile(file, allFiles.Length));
        }
       
        audioSource.clip = audioFiles[currentFileIndex];
    }

  /*
   * Loads files from the streaming assets folders successively. 
   * Excludes the meta files, that get generated automatically by unity
   * When all files are loaded the boolean dataLoaded gets true, so that
   * the controller can update the dropdown menu
   */

    IEnumerator LoadAudioFile(FileInfo audioFile, int folderSize)
    {
        if (audioFile.Name.Contains("meta"))
        {
            filesChecked++;
            if (filesChecked >= folderSize) { dataLoaded = true; }
            yield break;
        }
        else
        {
            string path = audioFile.FullName.ToString();
            string url = string.Format("file://{0}", path);
            WWW www = new WWW(url);
            yield return www;
           
            audioList.Add(www.GetAudioClip(false, false));
            audioFiles = audioList.ToArray();
            audioFiles[audioFiles.Length-1].name = audioFile.Name;
            filesChecked++;
           if (filesChecked>=folderSize) {
                audioSource.clip = audioFiles[currentFileIndex];
                dataLoaded = true;
            }

        }

        
    }

    void Update()
    {
        
    }

    //plays the audio or stops if there is one currently being played
    public void OnPlayAudio(float delay) {
        if (audioSource.isPlaying) { audioSource.Stop(); }
        else
        {
            audioSource.PlayDelayed(delay);
        }
       
    }

    //selects the next file
    public void OnNext() {
        audioSource.Stop();
        if (currentFileIndex < audioFiles.Length-1) {
            currentFileIndex++;
        }
        else { currentFileIndex = 0; }
        audioSource.clip = audioFiles[currentFileIndex];
    }
    //selects the previous file
    public void OnBack()
    {
        audioSource.Stop();
        if (currentFileIndex >0)
        {
            currentFileIndex--;
        }
        else { currentFileIndex = audioFiles.Length-1; }
        audioSource.clip = audioFiles[currentFileIndex];
    }

    //selects a certain file (the one chosen via the dropdown menu)
    public void OnTrackChosen(int index)
    {
        currentFileIndex = index;
        audioSource.clip = audioFiles[currentFileIndex];
    }

    //returns the name of the files so they can be shown on the UI
    public List<string> GetFileNames()
    {
        List<string> filenames = new List<string>();
        for(int i=0; i < audioFiles.Length; i++) { filenames.Add(audioFiles[i].name); }
        return filenames;

    }
    //sets the pitch
    public void UpdatePitch(float newPitch)
    {
        audioSource.pitch = newPitch;
    }

    //sets the volume
    public void UpdateVolume(float newVolume)
    {
        audioSource.volume = newVolume;
    }
    //returns the volume
    public float GetVolume()
    {
        return audioSource.volume;
    }

    //returns if a audio file is currently beeing played 
    public bool GetIsPlaying()
    {
        return audioSource.isPlaying;
    }

    //returns if all audio files are loaded 
    public bool GetIsReady()
    {
        return dataLoaded;
    }

    // returns the index of the current audio file. The index serves as identification
	public int GetCurrentFileIndex()
    {
        return currentFileIndex;
    }
}
