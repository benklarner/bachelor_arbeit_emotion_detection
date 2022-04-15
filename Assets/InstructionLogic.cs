using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;

public class InstructionLogic : MonoBehaviour
{
    public WriteToFile fileWriter;
    //Version Marius Fey
    public int Version = 0; //1 is without voice changer
    public int Gender = 0; //0 is female 1 is male

    public int weiter = 0;
    public GameObject verstandenToggle;
    public GameObject weiterButton;
    public GameObject zurückButton;
    public GameObject hilfeButton;
    public GameObject helpPanel;
    public GameObject content;

    public GameObject Infotext;
    public GameObject Studiencode;
    public InputField Code;
    public InputField SCode;
    public GameObject Datenschutz;
    public Toggle DatenschutzToggle;
    public Text tDatenschutz;

    public StringData stringData;



    private string sDatenschutzReplacement = "<b>Herzlich willkommen zum eigentlichen Experiment!</b>\n\nVielen Dank, dass " +
        "Sie sich die Zeit nehmen und uns so tatkräftig mit Ihrer Teilnahme unterstützen. " +
        "Bitte lesen Sie sich einmal alles in Ruhe durch und folgen Sie den Anweisungen auf den jeweiligen Seiten.\n\nSie können nun gerne beginnen!";
    /*private string sPsychoedukativeReplacementV1 = "Erklärung zu \"fehlerhaften\" Gedanken\n\nPersonen, greifen häufig auf \"fehlerhafte\", \"schlechte\" Gedanken," +
        " sog. dysfunktionale Annahmen zurück, wenn es darum geht, wie sie sich selber (und besonders Ihr Körperbild) wahrnehmen. \"Fehlerhafte\" Gedanken" +
        " stellen einen zentralen Ansatzpunkt in der Psychotherapie dar.\n\nWir möchten im Rahmen unserer Studie \"fehlerhafte\" Gedanken bearbeiten. Dabei " +
        "werden Sie durch eine virtuelle Person (sog. virtueller Agent) mit Ihren \"schlechten\" Gedanken konfrontiert. Es wird hierbei geübt, dem Agenten" +
        " zu widersprechen. Die Studie zielt darauf ab, \"fehlerhafte\" Gedanken zu minimieren und gleichzeitig \"gute\" sog. funktionale Annahmen zu fördern.";
    private string sPsychoedukativeReplacementV2 = "Erklärung zu \"fehlerhaften\" Gedanken\n\nPersonen, greifen häufig auf \"fehlerhafte\", \"schlechte\" Gedanken," +
       " sog. dysfunktionale Annahmen zurück, wenn es darum geht, wie sie sich selber (und besonders Ihr Körperbild) wahrnehmen. \"Fehlerhafte\" Gedanken" +
       " stellen einen zentralen Ansatzpunkt in der Psychotherapie dar.\n\nWir möchten im Rahmen unserer Studie \"fehlerhafte\" Gedanken bearbeiten. Dabei " +
       "werden Sie durch eine virtuelle Person (sog. virtueller Agent) mit Ihren \"schlechten\" Gedanken konfrontiert. Es wird hierbei geübt, dem Agenten" +
       " zu widersprechen. Die Studie zielt darauf ab, \"fehlerhafte\" Gedanken zu minimieren und gleichzeitig \"gute\" sog. funktionale Annahmen zu fördern.";
    private string sPsychoedukativeReplacementK = "Erklärung zu \"fehlerhaften\" Gedanken\n\n Personen, greifen häufig auf \"fehlerhafte\", \"schlechte\" Gedanken," +
        " sog. dysfunktionale Annahmen zurück, wenn es darum geht, wie sie sich selber (und besonders Ihr Körperbild) wahrnehmen. \"Fehlerhafte\" Gedanken" +
        " stellen einen zentralen Ansatzpunkt in der Psychotherapie dar.\n\nWir möchten im Rahmen unserer Studie \"fehlerhafte\" Gedanken bearbeiten. Dabei " +
        "werden Sie durch eine virtuelle Person (sog. virtueller Agent) mit objektiv falschen Aussagen konfrontiert. Es wird hierbei geübt, dem Agenten" +
        " zu widersprechen. Die Studie zielt darauf ab, \"fehlerhafte\" Gedanken zu minimieren und gleichzeitig \"gute\" sog. funktionale Annahmen zu fördern.";
     /*private string sInstruktionIndivReplacementV = "Personen besitzen ganz spezifische, individuelle, \"schlechte\" Gedanken, die Ihnen in bestimmten Situationen in den Kopf kommen.\n\n" +
         "Bitte überlegen Sie sich drei \"schlechte\" Gedanken, die Sie für sich als zutreffend empfinden sowie drei dazugehörige alternative, \"gute\" Gedanken.\n\n" +
         "Bitte geben Sie die \"schlechten\" Gedanken in DU-Botschaften an! Beispielsweise: \"Du bist nichts wert, niemand mag dich!\"\n\n" +
         "Bitte beachten Sie, dass Ihre Gedanken nur im Rahmen dieser Studie verwendet werden, <b><color=red>streng vertraulich</color></b> behandelt werden und nicht Ihrer Person zuordbar sind.";
     private string sInstruktionIndivReplacementK = "Personen besitzen ganz spezifische, individuelle, \"schlechte\" Gedanken, die Ihnen in bestimmten Situationen in den Kopf kommen.\n\n" +
     "Bitte überlegen Sie sich drei \"schlechte\" Gedanken, die Sie für sich als zutreffend empfinden sowie drei dazugehörige alternative, \"gute\" Gedanken.\n\n" +
     "Bitte geben Sie die \"schlechten\" Gedanken in DU-Botschaften an! Beispielsweise: \"Du bist lächerlich, niemand mag dich!\"\n\n" +
     "Bitte beachten Sie, dass Ihre Gedanken nur im Rahmen dieser Studie verwendet werden, <b><color=red>streng vertraulich</color></b> behandelt werden und nicht Ihrer Person zuordbar sind.";*/
    private string sNebenwirkungenV = "Nebenwirkungen\n\nBitte beachten Sie, dass im Rahmen der Studie einige Nebenwirkungen nicht vollkommen ausgeschlossen werden können.\n" +
        "Da in unserer Studie \"schlechte\" Gedanken bearbeitet werden, kann es sein, dass Sie dies zwischenzeitlich als unangenehm empfinden. Bitte beachten Sie, dass negative Gefühle" +
        " normale Reaktionen sind und vorübergehen. Sollten die Gefühle nicht vorübergehen, kontaktieren Sie bitte die Versuchsleiter.";
    private string sNebenwirkungenK = "Nebenwirkungen\n\nBitte beachten Sie, dass im Rahmen der Studie einige Nebenwirkungen, wie beispielsweise unangenehme Gefühle, nicht vollkommen ausgeschlossen werden können.\n" +
    "Bitte beachten Sie, dass negative Gefühle normale Reaktionen sind und vorübergehen. Sollten die Gefühle nicht vorübergehen, kontaktieren Sie bitte die Versuchsleiter.";
    public GameObject PsychoedukativeAufklaerung;
    public GameObject BeispielDysfunktionaleKognitionen;
    public GameObject InstruktionIndividuelleGedanken;
    public GameObject EigeneGedanken1;
    public Text tEigeneGedanken1;
    public InputField ifSchlechteGedanken1;
    public InputField ifGuteGedanken1;
    public GameObject ifZustimmung1;
    public GameObject tZustimmung1;
    public GameObject EigeneGedanken2;
    public Text tEigeneGedanken2;
    public InputField ifSchlechteGedanken2;
    public InputField ifGuteGedanken2;
    public GameObject ifZustimmung2;
    public GameObject tZustimmung2;
    public GameObject EigeneGedanken3;
    public Text tEigeneGedanken3;
    public InputField ifSchlechteGedanken3;
    public InputField ifGuteGedanken3;
    public GameObject ifZustimmung3;
    public GameObject tZustimmung3;
    public GameObject AufklaerungVersuch;
    public GameObject AufklaerungKontrolle;
    public GameObject KontrollmanipulationInstruktionen;
    public GameObject AufklaerungUeberNebenwirkungen;

    public Text tHilfeText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Mode", fileWriter.Mode);
        PlayerPrefs.SetString("Code", "");
        Infotext.SetActive(false);

        
        byte []mybites = System.Text.Encoding.UTF8.GetBytes(PlayerPrefs.GetString("ExperimentVersion"));
        
        foreach (byte b in mybites)
        {
            Debug.Log("Bytes " + b);
        }
        InstructionState();

        //weiterButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (weiter == 0)
        {
            if (Code.text.Length <= 6)
            {
                weiterButton.SetActive(false);
            }
            if (Code.text.Length >= 6)
            {
                weiterButton.SetActive(true);
            }
        }
        if (weiter == 1)
        {
            if ((!PlayerPrefs.GetString("Studiencode").Equals("")&&(SCode.text.Length<1)))
            {
                SCode.text = PlayerPrefs.GetString("Studiencode");
                Debug.Log("Studiencode: " + PlayerPrefs.GetString("Studiencode"));
            }
            if (SCode.text.Length <= 1)
            {
                weiterButton.SetActive(false);
            }
            if (SCode.text.Length >= 1)
            {
                weiterButton.SetActive(true);
            }
        }
    }

    public void InstructionState()
    {
        switch (weiter)
        {
            case 0:
                if (PlayerPrefs.GetString("Mode") != "3")
                {
                    if ((PlayerPrefs.GetString("Mode").Equals("1")) || (PlayerPrefs.GetString("Mode").Equals("2")))
                    {
                        Infotext.SetActive(true);
                        //PlayerPrefs.SetString("Code", Code.text);
                        GameObject.Find("DebugText").GetComponent<Text>().text = "Mode:" + PlayerPrefs.GetString("Mode") + "    Version:" + PlayerPrefs.GetString("ExperimentVersion") + "    Code:" + PlayerPrefs.GetString("Code");
                    }
                    if (PlayerPrefs.GetString("Mode").Equals("0"))
                    {
                        //PlayerPrefs.SetString("Code", Code.text);
                        GameObject.Find("DebugText").GetComponent<Text>().text = "Mode:" + PlayerPrefs.GetString("Mode") + "    Version:" + PlayerPrefs.GetString("ExperimentVersion") + "    Code:" + PlayerPrefs.GetString("Code");
                        Weiter();
                    } 
                }
                break;
            case 1:
                if ((PlayerPrefs.GetString("Mode") == "1") || (PlayerPrefs.GetString("Mode") == "2") || (PlayerPrefs.GetString("Mode") == "k"))
                {
                    PlayerPrefs.SetString("Code", Code.text.ToUpper());
                    GameObject.Find("DebugText").GetComponent<Text>().text = "Mode:" + PlayerPrefs.GetString("Mode") + "    Version:" + PlayerPrefs.GetString("ExperimentVersion") + "    Code:" + PlayerPrefs.GetString("Code");
                    //Weiter();
                    fileWriter.GetAllData();
                }
                //fileWriter.GetAllData();
                

                
                //Code.text = "";
                    

                Infotext.SetActive(false);
                Studiencode.SetActive(true);
                //ToggleCheck();
                
                /*tDatenschutz.text = sDatenschutzReplacement;
                Datenschutz.SetActive(true);
                GameObject.Find("DatenschutzToggle").SetActive(false);
                weiterButton.SetActive(true);*/
                //Weiter();
                break;
            case 2:
                
                PlayerPrefs.SetString("Studiencode", SCode.text);
                Studiencode.SetActive(false);


                //tDatenschutz.text = sDatenschutzReplacement;
                Datenschutz.SetActive(true);
                GameObject.Find("DatenschutzToggle").SetActive(true);
                ToggleCheck();
                //weiterButton.SetActive(false);
                /*Datenschutz.SetActive(false);
                PsychoedukativeAufklaerung.SetActive(true);
                if (PlayerPrefs.GetString("ExperimentVersion").Equals("1"))
                {
                    PsychoedukativeAufklaerung.GetComponent<Text>().text = stringData.sPsychoedukativeReplacementV1;
                }
                if (PlayerPrefs.GetString("ExperimentVersion").Equals("2"))
                {
                    PsychoedukativeAufklaerung.GetComponent<Text>().text = stringData.sPsychoedukativeReplacementV2;
                }
                if (PlayerPrefs.GetString("ExperimentVersion").Equals("k"))
                {
                   PsychoedukativeAufklaerung.GetComponent<Text>().text = stringData.sPsychoedukativeReplacementK;
                }*/

                break;
            case 3:
                //weiterButton.SetActive(false);
                Datenschutz.SetActive(false);
                //GameObject.Find("DatenschutzToggle").SetActive(false);
                // Weiter();
                //PsychoedukativeAufklaerung.SetActive(true);
                InstruktionIndividuelleGedanken.SetActive(true);
                BeispielDysfunktionaleKognitionen.SetActive(false);
                zurückButton.SetActive(false);
                //BeispielDysfunktionaleKognitionen.SetActive(true);
               /* //if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                //{
                BeispielDysfunktionaleKognitionen.GetComponent<Text>().text = stringData.sBeispielDysGedReplacementV1;
                //}
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    BeispielDysfunktionaleKognitionen.GetComponent<Text>().text = stringData.sBeispielDysGedReplacementV2;
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    BeispielDysfunktionaleKognitionen.GetComponent<Text>().text = stringData.sBeispielDysGedReplacementK;
                }*/
                
                break;
            case 4:
                //Weiter();
                //PsychoedukativeAufklaerung.SetActive(false);
                //zurückButton.SetActive(true);
                BeispielDysfunktionaleKognitionen.SetActive(true);
                InstruktionIndividuelleGedanken.SetActive(false);
                EigeneGedanken1.SetActive(false);
                /*if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    InstruktionIndividuelleGedanken.GetComponent<Text>().text = stringData.sInstruktionIndivReplacementV1;
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    InstruktionIndividuelleGedanken.GetComponent<Text>().text = stringData.sInstruktionIndivReplacementV2;
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    InstruktionIndividuelleGedanken.GetComponent<Text>().text = stringData.sInstruktionIndivReplacementK;
                }*/
                if (PlayerPrefs.GetInt("FirstRun") == 0)
                {
                    weiter = 9;
                    Weiter();
                }

                break;
            case 5:

                //InstruktionIndividuelleGedanken.SetActive(false);
                BeispielDysfunktionaleKognitionen.SetActive(false);
                EigeneGedanken1.SetActive(true);
                EigeneGedanken2.SetActive(false);
                GetGedanken2();
                Debug.Log(PlayerPrefs.GetString("GuterGedanke1"));
                if (PlayerPrefs.GetString("GuterGedanke1").Length > 0)
                {
                    ifGuteGedanken1.text = PlayerPrefs.GetString("GuterGedanke1");
                    ifGuteGedanken2.text = PlayerPrefs.GetString("GuterGedanke2");
                    ifGuteGedanken3.text = PlayerPrefs.GetString("GuterGedanke3");

                    ifSchlechteGedanken1.text = PlayerPrefs.GetString("SchlechterGedanke1");
                    ifSchlechteGedanken2.text = PlayerPrefs.GetString("SchlechterGedanke2");
                    ifSchlechteGedanken3.text = PlayerPrefs.GetString("SchlechterGedanke3");

                    ifZustimmung1.GetComponent<InputField>().text = PlayerPrefs.GetString("Zustimmung1");
                    ifZustimmung2.GetComponent<InputField>().text = PlayerPrefs.GetString("Zustimmung2");
                    ifZustimmung3.GetComponent<InputField>().text = PlayerPrefs.GetString("Zustimmung3");
                }
                weiterButton.SetActive(true);
                //hilfeButton.SetActive(true);
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    tEigeneGedanken1.text = stringData.sFormulierungGedankenBeispielV1;
                    tEigeneGedanken2.text = stringData.sFormulierungGedankenBeispielV1;
                    tEigeneGedanken3.text = stringData.sFormulierungGedankenBeispielV1;
                    //tHilfeText.text = stringData.sHilfeV1;
                    ifZustimmung1.SetActive(false);
                    tZustimmung1.SetActive(false);
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    tEigeneGedanken1.text = stringData.sFormulierungGedankenBeispielV2;
                    tEigeneGedanken2.text = stringData.sFormulierungGedankenBeispielV2;
                    tEigeneGedanken3.text = stringData.sFormulierungGedankenBeispielV2;
                    //tHilfeText.text = stringData.sHilfeV2;
                    ifZustimmung1.SetActive(true);
                    tZustimmung1.SetActive(true);
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    tEigeneGedanken1.text = stringData.sFormulierungGedankenBeispielK;
                    tEigeneGedanken2.text = stringData.sFormulierungGedankenBeispielK;
                    tEigeneGedanken3.text = stringData.sFormulierungGedankenBeispielK;
                    //tHilfeText.text = stringData.sHilfeK;
                    ifZustimmung1.SetActive(false);
                    tZustimmung1.SetActive(false);
                }

                break;
            case 6:
                GetGedanken1();
                GetGedanken2();
                if (PlayerPrefs.GetString("GuterGedanke2").Length > 0)
                {
                    ifGuteGedanken2.text = PlayerPrefs.GetString("GuterGedanke2");
                    ifSchlechteGedanken2.text = PlayerPrefs.GetString("SchlechterGedanke2");
                }
                EigeneGedanken1.SetActive(false);
                EigeneGedanken2.SetActive(true);
                EigeneGedanken3.SetActive(false);
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    ifZustimmung2.SetActive(false);
                    tZustimmung2.SetActive(false);
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    ifZustimmung2.SetActive(true);
                    tZustimmung2.SetActive(true);
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    ifZustimmung2.SetActive(false);
                    tZustimmung2.SetActive(false);
                }
                
                break;
            case 7:
                zurückButton.SetActive(true);
                GetGedanken2();
                GetGedanken3();
                if (PlayerPrefs.GetString("GuterGedanke2").Length > 0)
                {
                    ifGuteGedanken3.text = PlayerPrefs.GetString("GuterGedanke3");
                    ifSchlechteGedanken3.text = PlayerPrefs.GetString("SchlechterGedanke3");
                }
                EigeneGedanken2.SetActive(false);
                EigeneGedanken3.SetActive(true);
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    ifZustimmung3.SetActive(false);
                    tZustimmung3.SetActive(false);
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    ifZustimmung3.SetActive(true);
                    tZustimmung3.SetActive(true);
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    ifZustimmung3.SetActive(false);
                    tZustimmung3.SetActive(false);
                }
                break;
            case 8:
                zurückButton.SetActive(false);
                GetGedanken3();
                EigeneGedanken3.SetActive(false);
               // hilfeButton.SetActive(false);
                Weiter();
               // ToggleCheck();
               /* 
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    AufklaerungVersuch.SetActive(true);
                    AufklaerungVersuch.GetComponent<Text>().text = stringData.sAufklaerungVersuchV1;
                    verstandenToggle.SetActive(true);
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    AufklaerungVersuch.SetActive(true);
                    AufklaerungVersuch.GetComponent<Text>().text = stringData.sAufklaerungVersuchV2;
                    verstandenToggle.SetActive(true);
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    AufklaerungVersuch.SetActive(false);
                    Weiter();
                   // AufklaerungVersuch.GetComponent<Text>().text = stringData.sAufklaerungVersuchK;
                }
                /* if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                 {
                     AufklaerungKontrolle.SetActive(true);
                 }*/
                //verstandenToggle.SetActive(true);*/
                break;
            case 9:
                Weiter();
                /*if (Version == 0)
                {
                    AufklaerungKontrolle.SetActive(false);
                    AufklaerungVersuch.SetActive(false);
                    verstandenToggle.SetActive(false);
                    KontrollmanipulationInstruktionen.SetActive(true);
                }else
                {
                    AufklaerungKontrolle.SetActive(false);
                    AufklaerungVersuch.SetActive(false);
                    verstandenToggle.SetActive(false);
                    Weiter();
                }*/
                
                break;
            case 10:
                /*KontrollmanipulationInstruktionen.SetActive(false);
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    AufklaerungUeberNebenwirkungen.SetActive(true);
                    weiterButton.SetActive(false);
                    verstandenToggle.GetComponent<Toggle>().isOn = false;
                    verstandenToggle.SetActive(true);
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    Weiter();
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {

                    Weiter();
                }*/
                weiterButton.SetActive(false);
                Weiter();
                /*AufklaerungUeberNebenwirkungen.SetActive(true);
                weiterButton.SetActive(false);
                verstandenToggle.GetComponent<Toggle>().isOn = false;
                verstandenToggle.SetActive(true);*/
                break;
            case 11:
                if (Gender == 0)
                {
                    PlayerPrefs.SetInt("Gender", 0);
                    SceneManager.LoadScene("MainSceneFemale");

                }
                if (Gender == 1)
                {
                    PlayerPrefs.SetInt("Gender", 1);
                    SceneManager.LoadScene("MainSceneMale");
                }
                break;
                
        }
    }

    public void Schliessen()
    {
        helpPanel.SetActive(false);
    }
    public void HelpPanel()
    {
        helpPanel.SetActive(true);
        GameObject.Find("ScrollView").GetComponent<ScrollRect>().verticalNormalizedPosition = 1.0f;
    }

    public void Weiter()
    {
        weiter += 1;
        InstructionState();
    }
    public void Zurück()
    {
        weiter -= 1;
        InstructionState();
    }

    public void ToggleCheck()
    {
        if ((weiter == 8)||(weiter==10))
        {
            if (!verstandenToggle.GetComponent<Toggle>().isOn)
            {
                weiterButton.SetActive(false);
            }else
            {
                weiterButton.SetActive(true);
            }
        }
        if ((weiter == 1) || (weiter == 2))
        {
            if (!DatenschutzToggle.isOn)
            {
                weiterButton.SetActive(false);
            }
            if (DatenschutzToggle.isOn)
            {
                weiterButton.SetActive(true);
            }

        }
        
        
    }

    public void GetGedanken1()
    {
        if (PlayerPrefs.GetString("ExperimentVersion") == "1")
        {
            PlayerPrefs.SetString("GuterGedanke1", ifGuteGedanken1.text);
            PlayerPrefs.SetString("SchlechterGedanke1", ifSchlechteGedanken1.text);
            PlayerPrefs.SetString("Zustimmung1", "null");
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "2")
        {
            PlayerPrefs.SetString("GuterGedanke1", ifGuteGedanken1.text);
            PlayerPrefs.SetString("SchlechterGedanke1", ifSchlechteGedanken1.text);
            PlayerPrefs.SetString("Zustimmung1", ifZustimmung1.GetComponent<InputField>().text);
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "k")
        {
            PlayerPrefs.SetString("GuterGedanke1", ifGuteGedanken1.text);
            PlayerPrefs.SetString("SchlechterGedanke1", ifSchlechteGedanken1.text);
            PlayerPrefs.SetString("Zustimmung1", "null");
        }
        /*PlayerPrefs.SetString("GuterGedanke1", ifGuteGedanken1.text);
        PlayerPrefs.SetString("SchlechterGedanke1", ifSchlechteGedanken1.text);
        PlayerPrefs.SetString("Zustimmung1", ifZustimmung1.GetComponent<Text>().text);*/
    }
    public void GetGedanken2()
    {
        if (PlayerPrefs.GetString("ExperimentVersion") == "1")
        {
            PlayerPrefs.SetString("GuterGedanke2", ifGuteGedanken2.text);
            PlayerPrefs.SetString("SchlechterGedanke2", ifSchlechteGedanken2.text);
            PlayerPrefs.SetString("Zustimmung2", "null");
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "2")
        {
            PlayerPrefs.SetString("GuterGedanke2", ifGuteGedanken2.text);
            PlayerPrefs.SetString("SchlechterGedanke2", ifSchlechteGedanken2.text);
            PlayerPrefs.SetString("Zustimmung2", ifZustimmung2.GetComponent<InputField>().text);
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "k")
        {
            PlayerPrefs.SetString("GuterGedanke2", ifGuteGedanken2.text);
            PlayerPrefs.SetString("SchlechterGedanke2", ifSchlechteGedanken2.text);
            PlayerPrefs.SetString("Zustimmung2", "null");
        }
        /*PlayerPrefs.SetString("GuterGedanke2", ifGuteGedanken2.text);
        PlayerPrefs.SetString("SchlechterGedanke2", ifSchlechteGedanken2.text);
        PlayerPrefs.SetString("Zustimmung2", ifZustimmung2.GetComponent<Text>().text);*/
    }
    public void GetGedanken3()
    {
        if (PlayerPrefs.GetString("ExperimentVersion") == "1")
        {
            PlayerPrefs.SetString("GuterGedanke3", ifGuteGedanken3.text);
            PlayerPrefs.SetString("SchlechterGedanke3", ifSchlechteGedanken3.text);
            PlayerPrefs.SetString("Zustimmung3", "null");
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "2")
        {
            PlayerPrefs.SetString("GuterGedanke3", ifGuteGedanken3.text);
            PlayerPrefs.SetString("SchlechterGedanke3", ifSchlechteGedanken3.text);
            PlayerPrefs.SetString("Zustimmung3", ifZustimmung3.GetComponent<InputField>().text);
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "k")
        {
            PlayerPrefs.SetString("GuterGedanke3", ifGuteGedanken3.text);
            PlayerPrefs.SetString("SchlechterGedanke3", ifSchlechteGedanken3.text);
            PlayerPrefs.SetString("Zustimmung3", "null");
        }
        /*PlayerPrefs.SetString("GuterGedanke3", ifGuteGedanken3.text);
        PlayerPrefs.SetString("SchlechterGedanke3", ifSchlechteGedanken3.text);
        PlayerPrefs.SetString("Zustimmung3", ifZustimmung3.GetComponent<Text>().text);*/
    }
}
