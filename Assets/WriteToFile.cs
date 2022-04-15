using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection.Emit;

public class WriteToFile : MonoBehaviour {

	public string Information;
	public string ExperimentVersion;
	public string Code;
	public string Mode;
	// Use this for initialization
	public string data;
	private string FemaleUrl = "http://80.155.190.86/VRAgentBigV1_FER/fromunity.php";
	private string EmotionURL = "http://80.155.190.86/VRAgentBigV1_FER/emotion.php";
	public string url = "";
	public List<string> Thoughts = new List<string>();

	//public string test1;
	//public string test2;

	//public Text debugText;


	

	//public InstructionLogic _InstructionLogic;
	void Start () {
		//PlayerPrefs.DeleteAll();
		//PlayerPrefs.DeleteAll();
		if (SceneManager.GetActiveScene().name.ToString().Equals("MainSceneFemale"))
		{
			if (PlayerPrefs.GetString("ExperimentVersion").Equals("1"))
			{
				Debug.Log("V 1");
				FemaleUrl = "http://80.155.190.86/VRAgentBigV1_FER/fromunity.php";
				url = FemaleUrl;
			}
			if (PlayerPrefs.GetString("ExperimentVersion").Equals("2"))
			{
				Debug.Log("V 2");
				FemaleUrl = "http://80.155.190.86/VRAgentBigV1_FER/fromunity.php";
				url = FemaleUrl;
			}
			if (PlayerPrefs.GetString("ExperimentVersion").Equals("k"))
			{
				Debug.Log("V k");
				FemaleUrl = "http://80.155.190.86/VRAgentBigV1_FER/fromunity.php";
				url = FemaleUrl;
			}
		}
		

		/*if (PlayerPrefs.GetInt("Gender") == 0)
		{
			url = FemaleUrl;
		}
		else
		{
			//url = MaleUrl;
		}*/

		if (SceneManager.GetActiveScene().name.ToString() == "Instructions")
		{
			PlayerPrefs.SetString("Code", "");
			PlayerPrefs.SetString("Studiencode", "");
			PlayerPrefs.SetString("GuterGedanke1", "");
			PlayerPrefs.SetString("SchlechterGedanke1", "");
			PlayerPrefs.SetString("Zustimmung1", "");
			PlayerPrefs.SetString("GuterGedanke2", "");
			PlayerPrefs.SetString("SchlechterGedanke2", "");
			PlayerPrefs.SetString("Zustimmung2", "");
			PlayerPrefs.SetString("GuterGedanke3", "");
			PlayerPrefs.SetString("SchlechterGedanke3", "");
			PlayerPrefs.SetString("Zustimmung3", "");
			PlayerPrefs.SetString("Mode", Mode); //Mode is now always 2, the link button will be deactivated
			PlayerPrefs.SetString("ExperimentVersion", ExperimentVersion);
			PlayerPrefs.SetInt("FirstRun", 1);
			GameObject.Find("DebugText").GetComponent<Text>().text = "Mode:" + Mode + "    Version:" + ExperimentVersion + "    Code:" + Code; //+ "    komplett:" + Information;
			StartCoroutine(getSettingsFromFile());
			//StartCoroutine(getAllData());
			/*StartCoroutine(getInformationTextFromFile());
			StartCoroutine(getSettingsFromFile());
			PlayerPrefs.SetString("Mode", "3"); //this is to check if the data was received from the file. if so the value could not be 3. */
		}
		
	}

	


	IEnumerator sendEmotionsToFile()
	{
		bool successful = true;
		WWWForm form = new WWWForm();
		form.AddField("EmotionDataString", PlayerPrefs.GetString("EmotionData"));
		
		Debug.Log(PlayerPrefs.GetString("EmotionData"));

		WWW www = new WWW(EmotionURL, form);
		



		yield return www;
		if (www.error != null)
		{
			//Debug.Log("sended");
			successful = false;
		}
		else
		{
				//Debug.Log(www.text);
			successful = true;
		}
	}


	IEnumerator sendTextToFile()
	{
		bool successful = true;
		WWWForm form = new WWWForm();
		form.AddField("code", PlayerPrefs.GetString("Code") + ";");
		form.AddField("DataString", data);

		WWW www = new WWW(url, form);

		

		yield return www;
		if (www.error != null)
        {
			//Debug.Log("sended");
			successful = false;
        }
		else
        {
		//	Debug.Log(www.text);
			successful = true;
        }
	}

	IEnumerator getInformationTextFromFile()
	{
		bool successful = true;
		WWWForm form = new WWWForm();
		WWW www;

		switch (ExperimentVersion)
		{
			case "1":
				www = new WWW("http://80.155.190.86/VRAgentBigV1_FER/CodeToUnity.php"
					, form);
				break;
			case "2":
				www = new WWW("http://80.155.190.86/VRAgentBigV2/CodeToUnity.php", form); //here was v1 in, bug or wanted?
				break;
			case "k":
				www = new WWW("http://80.155.190.86/VRAgentBigV1_FER/CodeToUnity.php"
					, form);
				break;
			default:
				www = new WWW("", form);
				break;
		}



		yield return www;
		if (www.error != null)
		{
			successful = false;
			//debugText.GetComponent<Text>().text = www.text;
		}
		else
		{
			//Debug.Log(www.text);
			//debugText.GetComponent<Text>().text = www.text;
			Information = www.text.ToString();
			Mode = Information.Substring(0, 1);
			ExperimentVersion = Information.Substring(1, 1);//now is 1 or 2 or k
			Code = Information.Substring(2, Information.Length-2);
			GameObject.Find("DebugText").GetComponent<Text>().text = "Mode:" + Mode + "    Version:" + ExperimentVersion + "    Code:" + Code; //+ "    komplett:" + Information;
			PlayerPrefs.SetString("Mode", Mode);
			PlayerPrefs.SetString("ExperimentVersion", ExperimentVersion);
			PlayerPrefs.SetString("Code", Code.Substring(0, Code.Length-1));
			GameObject.Find("Scriptholder").GetComponent<InstructionLogic>().InstructionState();
			//PlayerPrefs.SetString("Code", Code);
			successful = true;
			
		}
	}

	IEnumerator getSettingsFromFile()
	{
		bool successful = true;
		WWWForm form = new WWWForm();
		WWW www;// = new WWW("http://80.155.190.86/VRAgentBig/Settings.php", form);

		switch (ExperimentVersion)
		{
			case "1":
				www = new WWW("http://80.155.190.86/VRAgentBigV1_FER/Settings.php"
					, form);
				break;
			case "2":
				www = new WWW("http://80.155.190.86/VRAgentBigV1_FER/Settings.php"
					, form);
				break;
			case "k":
				www = new WWW("http://80.155.190.86/VRAgentBigV1_FER/Settings.php"
					, form);
				break;
			default:
				www = new WWW("", form);
				break;
		}


		yield return www;
		if (www.error != null)
		{
			successful = false;
			//debugText.GetComponent<Text>().text = www.text;
		}
		else
		{
			//Debug.Log(www.text);
			string[] linesInString = www.text.Split('\n');
			foreach(string line in linesInString)
			{
				//Debug.Log(line);
			}
			//test1 = linesInString[0];
			//test2 = linesInString[1];
			PlayerPrefs.SetString("TimeToPause", linesInString[0]);
			PlayerPrefs.SetString("EndUrl", linesInString[1]);
			PlayerPrefs.SetString("ApplicationState", linesInString[2]);
			if (PlayerPrefs.GetString("ApplicationState") == "debug")
			{
				GameObject.Find("DebugText").GetComponent<Text>().enabled = true;
			}
			else { GameObject.Find("DebugText").GetComponent<Text>().enabled = false; }
			 /*test1 = www.text.Substring(0,www.text.IndexOf("/n1"));
			 Debug.Log(www.text.IndexOf("/n2"));
			 test2 = www.text.Substring(www.text.IndexOf("/n1")+4, www.text.IndexOf("/n2")-6);
			 PlayerPrefs.SetString("TimeToPause", test1);
			 PlayerPrefs.SetString("EndUrl", test2);*/
			 successful = true;
		}
	}


	IEnumerator getAllData()
	{
		bool successful = true;
		WWWForm form = new WWWForm();
		WWW www = new WWW("http://80.155.190.86/VRAgentBigV1_FER/GetAllData.php"
			, form);



		switch (ExperimentVersion)
		{
			case "1":
				www = new WWW("http://80.155.190.86/VRAgentBigV1_FER/GetAllData.php"
			, form);

				break;
			case "2":
				www = new WWW("http://80.155.190.86/VRAgentBigV1_FER/GetAllData.php"
			, form);

				break;
			case "k":
				www = new WWW("http://80.155.190.86/VRAgentBigV1_FER/GetAllData.php"
			, form);

				break;
			default:
				www = new WWW("", form);
				break;
		}



		yield return www;
		if (www.error != null)
		{
			successful = false;
			//debugText.GetComponent<Text>().text = www.text;
		}
		else
		{
			//Debug.Log(www.text);
			string[] linesInString = www.text.Split('\n');
			foreach (string line in linesInString)
			{
				//Debug.Log("All :    " + line);
				string[] dataInString = line.Split(';');
				if (dataInString[0].Equals(PlayerPrefs.GetString("Code")))
				{
					Debug.Log(line);
					PlayerPrefs.SetString("Studiencode", dataInString[2]);
					PlayerPrefs.SetString("GuterGedanke1", dataInString[6]);
					PlayerPrefs.SetString("SchlechterGedanke1", dataInString[7]);
					PlayerPrefs.SetString("Zustimmung1", dataInString[8]);
					PlayerPrefs.SetString("GuterGedanke2", dataInString[9]);
					PlayerPrefs.SetString("SchlechterGedanke2", dataInString[10]);
					PlayerPrefs.SetString("Zustimmung2", dataInString[11]);
					PlayerPrefs.SetString("GuterGedanke3", dataInString[12]);
					PlayerPrefs.SetString("SchlechterGedanke3", dataInString[13]);
					PlayerPrefs.SetString("Zustimmung3", dataInString[14]);
					Debug.Log("GuterGedanke1: " + dataInString[6]);
					if (dataInString[6].Length < 2)
					{
						PlayerPrefs.SetInt("FirstRun", 1);
					}
					else
					{
						PlayerPrefs.SetInt("FirstRun", 0);
					}
				}
				
			}
			
			
			successful = true;
		}
	}


	public void SendData()
    {
		StartCoroutine(sendTextToFile());
    }
	public void GetInformation()
	{
		StartCoroutine(getInformationTextFromFile());
	}
	public void GetSettings()
	{
		StartCoroutine(getSettingsFromFile());
	}
	public void GetAllData()
	{
		StartCoroutine(getAllData());
	}
	public void sendEmotionData()
    {
		StartCoroutine(sendEmotionsToFile());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
