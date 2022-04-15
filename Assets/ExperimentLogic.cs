using Crosstales.RTVoice.Tool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ExperimentLogic : MonoBehaviour
{
    //Marius Fey
    public int Version;

    public int Run = 0;
    private int Cycle = 0;
    bool startSlide32 = false;

    public GameObject btnPlay;
    public GameObject tgglWiedersprochen;
    public GameObject btnWeiter;
    public GameObject btnUIWeiter;
    public GameObject sliderTonhoehe;
    public GameObject DefinierteAntwort;
    public GameObject UebugnstextVerusch;
    public GameObject UebungstextKontrolle;

    public GameObject Uebungsdurchgang;
    public GameObject Durchgang1;
    public GameObject TextD1;
    public GameObject Durchgang2;
    public GameObject TextD2;
    public GameObject Durchgang3;
    public GameObject TextD3;
    public GameObject Durchgang4;
    public GameObject TextD4;
    public GameObject Durchgang5;
    public GameObject TextD5;
    public GameObject Durchgang6;
    public GameObject TextD6;
    public GameObject Durchgang7;
    public GameObject TextD7;
    public GameObject Durchgang8;
    public GameObject TextD8;
    public GameObject Durchgang9;
    public GameObject TextD9;
    public GameObject Durchgang10;
    public GameObject TextD10;
    public GameObject PauseScreen;
    public GameObject PauseButton;
    public GameObject Schwierigkeitstraining;
    public Text STrainingMainText;
    public Text SGedanke1;
    public Slider SGedanke1Slider;
    public Text SGedanke1Value;
    public Text SGedanke2;
    public Slider SGedanke2Slider;
    public Text SGedanke2Value;
    public Text SGedanke3;
    public Slider SGedanke3Slider;
    public Text SGedanke3Value;
    public GameObject Kontrollrating;
    public InputField KontrollValue;
    public GameObject Verabschiedung;
    public Text tVerabschiedung;

    public GameObject ButtonZurück;

    private string sVerabschiedungNoLink= "Mit Ihrer Teilnahme haben Sie einen großen Beitrag zur Wissenschaft geleistet.\n\nVielen Dank!\n\n" +
        "Indem wir das menschliche Denken besser verstehen lernen, können psychische Erkrankungen künftig effizienter behandelt werden.";
    private string sVerabschiedungLink= "Mit Ihrer Teilnahme haben Sie einen großen Beitrag zur Wissenschaft geleistet.\n\nVielen Dank!\n\n" +
        "Indem wir das menschliche Denken besser verstehen lernen, können psychische Erkrankungen künftig effizienter behandelt werden." +
        "\n\n<b><color=red>Achtung!</color> Die heutige Sitzung ist noch nicht beendet. Die folgende Umfrage stellt den letzten Teil der Studie dar. Vielen Dank für Ihre Geduld und Ihren wertvollen Beitrag zum Erfolg dieses Forschungsprojektes.</b>";

    private string sSchwierigkeitstratingV = "<color=red>Schwierigkeitsrating</color>\n\nBitte geben Sie nun ein Rating darüber ab, wie schwer es Ihnen am Ende der Sitzung gefallen ist dem virtuellen Agent zu widersprechen.\n\nSkala von 0-100 (0 = gar nicht schwer; 100 = sehr schwer)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"schlechten\" Gedanken ab.";
    private string sDysfunktionaleGedankenV = "Überzeugung des <color=red>dysfunktionalen Gedankens</color>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie sind, dass der jeweilige \"schlechte\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = absolut überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"schlechten\" Gedanken ab.";
    private string sAlternativeGedankenV = "Überzeugung des <color=red>alternativen Gedankens</color>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie sind, dass der jeweilige alternative, \"gute\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = sehr überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"guten\" Gedanken ab.";

    private string sSchwierigkeitstratingK = "<color=red>Schwierigkeitsrating</color>\n\nBitte geben Sie nun ein Rating darüber ab, wie schwer es Ihnen am Ende der Sitzung gefallen ist dem virtuellen Agent zu widersprechen.\n\nSkala von 0-100 (0 = gar nicht schwer; 100 = sehr schwer)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei schlechten Gedanken ab.";
    private string sDysfunktionaleGedankenK = "Überzeugung des <color=red>dysfunktionalen Gedankens</color>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie sind, dass der jeweilige \"schlechte\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = absolut überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"schlechten\" Gedanken ab.";
    private string sAlternativeGedankenK = "Überzeugung des <color=red>alternativen Gedankens</color>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie sind, dass der jeweilige alternative, \"gute\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = sehr überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"guten\" Gedanken ab.";


    private string sUebungsaussageVersuch = "Du wirst mehr geliebt, wenn Du schlanker bist.";
    private string sUebungsantwortVersuch = "Nein, das stimmt nicht. Ich muss nicht perfekt sein, um von anderen gemocht zu werden.";

    private string sUebungsaussageKontrolle = "In Deutschland bezahlt man mit Dollar.";
    private string sUebungsantwortKontrolle = "Nein, das stimmt nicht. Die Landeswährung ist der Euro.";

    private string sAussageKontrolle1 = "Eine Kuh kann fliegen.";
    private string sAussageKontrolle2 = "Hamburg ist die Hauptstadt von Deutschland.";
    private string sAussageKontrolle3 = "In der Ant arktis ist es meist wahrm.";
    private string sAussageKontrolle3_Replaced = "In der Antarktis ist es meist warm.";
    private string sAntwortKontrolle1 = "Nein, das stimmt nicht. Eine Kuh läuft mit den Füßen.";
    private string sAntwortKontrolle2 = "Nein, das stimmt nicht. Berlin ist die Hauptstadt von Deutschland.";
    private string sAntwortKontrolle3 = "Nein, das stimmt nicht. Dort ist es meist kalt.";

    public float PauseTimer = 0.0f;
    public Text TimerText;
    public int TimeToPause = 10;
    public GameObject btnPauseWeiter;
    private bool PauseDone = false;

    public SpeechText _SpeechText;

    public AudioSource _SpeechSource;
    public bool bPlayClicked = false;
    public bool debugPlay = false;
    public float debugPlayTimer = 0.0f;

    public float[] fPitch;
    public float[] fSliderValues;

    public StringData stringData;
    /*public float fGedanke1_1;
    public float fGedanke2_1;
    public float fGedanke3_1;
    public float fGedanke1_2;
    public float fGedanke2_2;
    public float fGedanke3_2;
    public float fGedanke1_3;
    public float fGedanke2_3;
    public float fGedanke3_3;*/
    public int iKontrolle;

    public WriteToFile fileWriter;
    public string dataString = "";

    public GameObject LinkButton;

    private string sDurchgang1V1 = "<b>Durchgang 1</b>\n\nIn der Folge beginnt nun der erste von 3 Durchgängen. Hierbei werden Sie mit allen drei <b>\"ungünstigen\"</b> Gedanken der Reihe nach konfrontiert und <b>widersprechen</b> diesen laut.";
    private string sDurchgang1V2 = "<b>Durchgang 1</b>\n\nIn der Folge beginnt nun der erste von 3 Durchgängen. Hierbei werden Sie mit allen drei <b>\"guten\"</b> Gedanken der Reihe nach konfrontiert und stimmen diesen laut zu.";
    private string sDurchgang1K = "<b>Durchgang 1</b>\n\nIn der Folge beginnt nun der erste von 3 Durchgängen. Hierbei werden Sie mit <b>allgemeinen</b>, nicht zutreffenden Aussagen konfrontiert und <b>widersprechen</b> diesen laut.";
    private string sDurchgang2V1 = "<b>Durchgang 2</b>\n\nIn der Folge beginnt nun der zweite von 3 Durchgängen. Hierbei werden Sie mit allen drei <b>\"ungünstigen\"</b> Gedanken der Reihe nach konfrontiert und <b>widersprechen</b> diesen laut.";
    private string sDurchgang2V2 = "<b>Durchgang 2</b>\n\nIn der Folge beginnt nun der zweite von 3 Durchgängen. Hierbei werden Sie mit allen drei <b>\"guten\"</b> Gedanken der Reihe nach konfrontiert und stimmen diesen laut zu.";
    private string sDurchgang2K = "<b>Durchgang 2</b>\n\nIn der Folge beginnt nun der zweite von 3 Durchgängen. Hierbei werden Sie mit <b>allgemeinen</b>, nicht zutreffenden Aussagen konfrontiert und <b>widersprechen</b> diesen laut.";
    private string sDurchgang3V1 = "<b>Durchgang 3</b>\n\nIn der Folge beginnt nun der dritte von 3 Durchgängen. Hierbei werden Sie mit allen drei <b>\"ungünstigen\"</b> Gedanken der Reihe nach konfrontiert und <b>widersprechen</b> diesen laut.";
    private string sDurchgang3V2 = "<b>Durchgang 3</b>\n\nIn der Folge beginnt nun der dritte von 3 Durchgängen. Hierbei werden Sie mit allen drei <b>\"guten\"</b> Gedanken der Reihe nach konfrontiert und stimmen diesen laut zu.";
    private string sDurchgang3K = "<b>Durchgang 3</b>\n\nIn der Folge beginnt nun der dritte von 3 Durchgängen. Hierbei werden Sie mit <b>allgemeinen</b>, nicht zutreffenden Aussagen konfrontiert und <b>widersprechen</b> diesen laut.";
    private string sDurchgang4V1 = "Durchgang 4\n\nIn der Folge beginnt nun der vierte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Gedanken der Reihe nach konfrontiert und widersprechen</b> diesen.";
    private string sDurchgang4V2 = "Durchgang 1\n\nIn der Folge beginnt nun der erste von 3 Durchgängen. Hierbei werden Sie mit allen drei \"guten\" Gedanken der Reihe nach konfrontiert und stimmen diesen zu.";
    private string sDurchgang4K = "Durchgang 4\n\nIn der Folge beginnt nun der vierte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Aussagen der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang5V1 = "Durchgang 5\n\nIn der Folge beginnt nun der fünfte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Gedanken der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang5V2 = "Durchgang 1\n\nIn der Folge beginnt nun der erste von 3 Durchgängen. Hierbei werden Sie mit allen drei \"guten\" Gedanken der Reihe nach konfrontiert und stimmen diesen zu.";
    private string sDurchgang5K = "Durchgang 5\n\nIn der Folge beginnt nun der fünfte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Aussagen der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang6V1 = "Durchgang 3\n\nIn der Folge beginnt nun der sechste von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Gedanken der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang6V2 = "Durchgang 1\n\nIn der Folge beginnt nun der erste von 3 Durchgängen. Hierbei werden Sie mit allen drei \"guten\" Gedanken der Reihe nach konfrontiert und stimmen diesen zu.";
    private string sDurchgang6K = "Durchgang 3\n\nIn der Folge beginnt nun der sechste von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Aussagen der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang7V1 = "Durchgang 7\n\nIn der Folge beginnt nun der siebte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Gedanken der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang7K = "Durchgang 7\n\nIn der Folge beginnt nun der siebte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Aussagen der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang8V1 = "Durchgang 8\n\nIn der Folge beginnt nun der achte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Gedanken der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang8K = "Durchgang 8\n\nIn der Folge beginnt nun der achte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Aussagen der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang9V1 = "Durchgang 9\n\nIn der Folge beginnt nun der neunte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Gedanken der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang9K = "Durchgang 9\n\nIn der Folge beginnt nun der neunte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Aussagen der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang10V1 = "Durchgang 10\n\nIn der Folge beginnt nun der zehnte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Gedanken der Reihe nach konfrontiert und widersprechen diesen.";
    private string sDurchgang10K = "Durchgang 10\n\nIn der Folge beginnt nun der zehnte von 3 Durchgängen. Hierbei werden Sie mit allen drei \"ungünstigen\" Aussagen der Reihe nach konfrontiert und widersprechen diesen.";


    
    // Start is called before the first frame update
    void Start()
    {
        ButtonZurück.SetActive(false);
        Version = PlayerPrefs.GetInt("Version");
        fPitch = new float[31]; //there are 31 runs. 1 for training, 30 for research. it goes form 0 to 30
        fSliderValues = new float[9]; //0 to 8 = 9 values
        SceneActions();
        //PauseTimer = float.Parse(PlayerPrefs.GetString("TimeToPause"));
        TimeToPause = (int)float.Parse(PlayerPrefs.GetString("TimeToPause"));//.Substring(0,PlayerPrefs.GetString("TimeToPause").Length-2));

        if (PlayerPrefs.GetString("ExperimentVersion") == "1")
        {
            UebungstextKontrolle.SetActive(false);
            Run = 32;
            fSliderValues[0] = 0;
            fSliderValues[1] = 0;
            fSliderValues[2] = 0;
            fSliderValues[3] = 0;
            fSliderValues[4] = 0;
            fSliderValues[5] = 0;
            fSliderValues[6] = 0;
            fSliderValues[7] = 0;
            fSliderValues[8] = 0;
            StartConfig();
            /*
             UebugnstextVerusch.SetActive(true);
             UebugnstextVerusch.GetComponent<Text>().text = stringData.sUebungstextVersuchV1;*/
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "2")
        {
            UebungstextKontrolle.SetActive(false);
            Run = 32;
            fSliderValues[0] = 0;
            fSliderValues[1] = 0;
            fSliderValues[2] = 0;
            fSliderValues[3] = 0;
            fSliderValues[4] = 0;
            fSliderValues[5] = 0;
            fSliderValues[6] = 0;
            fSliderValues[7] = 0;
            fSliderValues[8] = 0;
            StartConfig();
            /* Run =32
             UebugnstextVerusch.SetActive(true);
             UebugnstextVerusch.GetComponent<Text>().text = stringData.sUebungstextVersuchV2;
             tgglWiedersprochen.GetComponentInChildren<Text>().text = stringData.sToggleTextV2;*/
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "k")
        {
            UebungstextKontrolle.SetActive(false);
            Run = 32;
            fSliderValues[0] = 0;
            fSliderValues[1] = 0;
            fSliderValues[2] = 0;
            fSliderValues[3] = 0;
            fSliderValues[4] = 0;
            fSliderValues[5] = 0;
            fSliderValues[6] = 0;
            fSliderValues[7] = 0;
            fSliderValues[8] = 0;
            StartConfig();
        }
        setTextVersions();
    }


    // Update is called once per frame
    void Update()
    {

        sliderTonhoehe.SetActive(false);

        if (bPlayClicked)
        {
            debugPlayTimer += Time.deltaTime;
        }
        
        if ((debugPlayTimer>=3.0f)&&(!_SpeechSource.isPlaying)&&(bPlayClicked))
        {
            tgglWiedersprochen.SetActive(true);
            DefinierteAntwort.SetActive(true);

            if (PlayerPrefs.GetString("ExperimentVersion") == "2")
            {
                GameObject.Find("LabelTglW").GetComponent<Text>().text = "Ich habe zugestimmt";
            }
        }

        if (Run == 10)//16)
        {
            //float PauseLength = 10.0f;
            if (PauseTimer < TimeToPause) { 
                PauseTimer += Time.deltaTime;
                float ticker = TimeToPause - PauseTimer;
                int t = (int)ticker;
                TimerText.text = t.ToString();
            }
            if ((PauseTimer >= TimeToPause) && (!PauseDone))
            {
                //btnPauseWeiter.SetActive(true);
                PauseDone = true;
                PauseEnds();
            }
            
        }

        if ((Run == 31) || (Run == 32) || (Run == 33))
        {
            ShowSliderValues();

            switch (Run)
            {
                case 31:
                    fSliderValues[0] = SGedanke1Slider.value;
                    fSliderValues[1] = SGedanke2Slider.value;
                    fSliderValues[2] = SGedanke3Slider.value;
                    break;
                case 32:
                    fSliderValues[3] = SGedanke1Slider.value;
                    fSliderValues[4] = SGedanke2Slider.value;
                    fSliderValues[5] = SGedanke3Slider.value;
                    break;
                case 33:
                    fSliderValues[6] = SGedanke1Slider.value;
                    fSliderValues[7] = SGedanke2Slider.value;
                    fSliderValues[8] = SGedanke3Slider.value;
                    break;
            }
        }

    }

    public void setTextVersions()
    {
        if (PlayerPrefs.GetString("ExperimentVersion") == "1")
        {
            TextD1.GetComponent<Text>().text = sDurchgang1V1;
            TextD2.GetComponent<Text>().text = sDurchgang2V1;
            TextD3.GetComponent<Text>().text = sDurchgang3V1;
            TextD4.GetComponent<Text>().text = sDurchgang4V1;
            TextD5.GetComponent<Text>().text = sDurchgang5V1;
            TextD6.GetComponent<Text>().text = sDurchgang6V1;
            TextD7.GetComponent<Text>().text = sDurchgang7V1;
            TextD8.GetComponent<Text>().text = sDurchgang8V1;
            TextD9.GetComponent<Text>().text = sDurchgang9V1;
            TextD10.GetComponent<Text>().text = sDurchgang10V1;
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "2")
        {
            TextD1.GetComponent<Text>().text = sDurchgang1V2;
            TextD2.GetComponent<Text>().text = sDurchgang2V2;
            TextD3.GetComponent<Text>().text = sDurchgang3V2;
            TextD4.GetComponent<Text>().text = sDurchgang4V2;
            TextD5.GetComponent<Text>().text = sDurchgang5V2;
            TextD6.GetComponent<Text>().text = sDurchgang6V2;
            TextD7.GetComponent<Text>().text = sDurchgang7V1;
            TextD8.GetComponent<Text>().text = sDurchgang8V1;
            TextD9.GetComponent<Text>().text = sDurchgang9V1;
            TextD10.GetComponent<Text>().text = sDurchgang10V1;
        }
        if (PlayerPrefs.GetString("ExperimentVersion") == "k")
        {
            TextD1.GetComponent<Text>().text = sDurchgang1K;
            TextD2.GetComponent<Text>().text = sDurchgang2K;
            TextD3.GetComponent<Text>().text = sDurchgang3K;
            TextD4.GetComponent<Text>().text = sDurchgang4K;
            TextD5.GetComponent<Text>().text = sDurchgang5K;
            TextD6.GetComponent<Text>().text = sDurchgang6K;
            TextD7.GetComponent<Text>().text = sDurchgang7K;
            TextD8.GetComponent<Text>().text = sDurchgang8K;
            TextD9.GetComponent<Text>().text = sDurchgang9K;
            TextD10.GetComponent<Text>().text = sDurchgang10K;
        }

    }

    public void PauseEnds()
    {
        PauseScreen.SetActive(false);
        btnUIWeiter.SetActive(true);
        //WeiterButtonPressed();
    }

    public void PlayClicked()
    {
        fPitch[Run] = sliderTonhoehe.GetComponent<Slider>().value;
        bPlayClicked = true;
        btnPlay.SetActive(false);
        sliderTonhoehe.SetActive(false);
        
    }

    public void WeiterButtonPressed()
    {
        

    
            Run += 1;
        
        
        if (Run == 10)
        {
            Run = 31;
        }

       /* if (PlayerPrefs.GetString("ExperimentVersion").Equals("2"))
        {
            if (Run == 33)
            {
                fSliderValues[6] = -1;
                fSliderValues[7] = -1;
                fSliderValues[8] = -1;
                Run = 34;
            }
        }*/


        /*if (Run >= 31)
        {
            Run += 1;
        }*/
        //SceneActions();
      
        StartConfig();
        
        
    }

    public void SceneActions()
    {
        switch (Run)
        {
            case 0:
                StartConfig();
                break;

        }
    }

    public void StartConfig()
    {
        if (Version == 0)
        {
            sliderTonhoehe.SetActive(true);
            sliderTonhoehe.GetComponent<Slider>().value = 1.0f;
        }

        DefinierteAntwort.SetActive(false);
        btnWeiter.SetActive(false);
        btnPlay.SetActive(true);
        tgglWiedersprochen.SetActive(false);
        tgglWiedersprochen.GetComponent<Toggle>().isOn = false;
        debugPlayTimer = 0f;
        bPlayClicked = false;
        switch (Run)
        {
            case 0:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = sUebungsaussageVersuch;//"Wenn du Fehler machst, werden die anderen dich ablehnen.";
                    DefinierteAntwort.GetComponent<Text>().text = sUebungsantwortVersuch;//"Nein, das stimmt nicht. Ich muss nicht perfekt sein, um von anderen akzeptiert zu werden.";
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sUebungsaussageKontrolle;//"Wenn du Fehler machst, werden die anderen dich ablehnen.";
                    DefinierteAntwort.GetComponent<Text>().text = sUebungsantwortKontrolle;//"Nein, das stimmt nicht. Ich muss nicht perfekt sein, um von anderen akzeptiert zu werden.";
                }

                btnUIWeiter.SetActive(true);
                Uebungsdurchgang.SetActive(true);
                break;
            case 1:
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("GuterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("Zustimmung1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(true);
                Durchgang1.SetActive(true);
                break;
            case 2:
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("GuterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("Zustimmung2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 3:
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("GuterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("Zustimmung3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 4:
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("GuterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("Zustimmung1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(true);
                Durchgang2.SetActive(true);
                break;
            case 5:
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("GuterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("Zustimmung2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 6:
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("GuterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("Zustimmung3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 7:
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("GuterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("Zustimmung1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(true);
                Durchgang3.SetActive(true);
                break;
            case 8:
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("GuterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("Zustimmung2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 9:
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("GuterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("Zustimmung3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 10:

                PauseScreen.SetActive(true);
                PauseButton.SetActive(false);
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(false);
                Durchgang4.SetActive(true);
                break;
            case 11:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 12:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 13:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(true);
                Durchgang5.SetActive(true);
                break;
            case 14:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 15:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 16:
 
               // PauseScreen.SetActive(true);
               // PauseButton.SetActive(false);
                
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(true);
                Durchgang6.SetActive(true);
                break;
            case 17:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 18:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 19:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(true);
                Durchgang7.SetActive(true);
                break;
            case 20:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 21:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 22:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(true);
                Durchgang8.SetActive(true);
                break;
            case 23:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 24:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 25:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(true);
                Durchgang9.SetActive(true);
                break;
            case 26:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 27:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 28:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke1");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke1");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle1;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle1;
                }
                btnUIWeiter.SetActive(true);
                Durchgang10.SetActive(true);
                break;
            case 29:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke2");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke2");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle2;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle2;
                }
                break;
            case 30:
                if (PlayerPrefs.GetString("ExperimentVersion") == "v")
                {
                    _SpeechText.Text = PlayerPrefs.GetString("SchlechterGedanke3");
                    DefinierteAntwort.GetComponent<Text>().text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    _SpeechText.Text = sAussageKontrolle3;
                    DefinierteAntwort.GetComponent<Text>().text = sAntwortKontrolle3;
                }
                break;
            case 31:
                btnWeiter.SetActive(true);
                ButtonZurück.SetActive(false);
                Schwierigkeitstraining.SetActive(true);
                SGedanke1Slider.value = fSliderValues[0];
                SGedanke2Slider.value = fSliderValues[1];
                SGedanke3Slider.value = fSliderValues[2];
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    STrainingMainText.text = stringData.sSchwierigkeitstratingV1;// sSchwierigkeitstratingV;
                    SGedanke1.text = PlayerPrefs.GetString("SchlechterGedanke1");
                    SGedanke2.text = PlayerPrefs.GetString("SchlechterGedanke2");
                    SGedanke3.text = PlayerPrefs.GetString("SchlechterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    STrainingMainText.text = stringData.sSchwierigkeitstratingV2;// sSchwierigkeitstratingV;
                    SGedanke1.text = PlayerPrefs.GetString("GuterGedanke1");
                    SGedanke2.text = PlayerPrefs.GetString("GuterGedanke2");
                    SGedanke3.text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    STrainingMainText.text = stringData.sSchwierigkeitstratingK;
                    SGedanke1.text = sAussageKontrolle1;
                    SGedanke2.text = sAussageKontrolle2;
                    SGedanke3.text = sAussageKontrolle3_Replaced;
                }
                    break;
            case 32:
                btnWeiter.SetActive(true);
                if (startSlide32)
                {
                    ButtonZurück.SetActive(true);
                }
                startSlide32 = true;

                Schwierigkeitstraining.SetActive(true);
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    STrainingMainText.text = stringData.sDysfunktionaleGedankenV1;// sDysfunktionaleGedankenV;
                    SGedanke1.text = PlayerPrefs.GetString("SchlechterGedanke1");
                    SGedanke2.text = PlayerPrefs.GetString("SchlechterGedanke2");
                    SGedanke3.text = PlayerPrefs.GetString("SchlechterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    STrainingMainText.text = stringData.sDysfunktionaleGedankenV2;
                    SGedanke1.text = PlayerPrefs.GetString("SchlechterGedanke1");
                    SGedanke2.text = PlayerPrefs.GetString("SchlechterGedanke2");
                    SGedanke3.text = PlayerPrefs.GetString("SchlechterGedanke3");
                }
        
                    
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    STrainingMainText.text = stringData.sDysfunktionaleGedankenK;//sDysfunktionaleGedankenK;
                    SGedanke1.text = PlayerPrefs.GetString("SchlechterGedanke1");
                    SGedanke2.text = PlayerPrefs.GetString("SchlechterGedanke2");
                    SGedanke3.text = PlayerPrefs.GetString("SchlechterGedanke3");
                }
                SGedanke1Slider.value = fSliderValues[3];
                SGedanke2Slider.value = fSliderValues[4];
                SGedanke3Slider.value = fSliderValues[5];
                break;
            case 33:
                btnWeiter.SetActive(true);
                
                if (PlayerPrefs.GetString("ExperimentVersion") == "1")
                {
                    STrainingMainText.text = stringData.sAlternativeGedankenV1;//sAlternativeGedankenV;
                    SGedanke1.text = PlayerPrefs.GetString("GuterGedanke1");
                    SGedanke2.text = PlayerPrefs.GetString("GuterGedanke2");
                    SGedanke3.text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "2")
                {
                    STrainingMainText.text = stringData.sAlternativeGedankenV2;// sSchwierigkeitstratingV;
                    SGedanke1.text = PlayerPrefs.GetString("GuterGedanke1");
                    SGedanke2.text = PlayerPrefs.GetString("GuterGedanke2");
                    SGedanke3.text = PlayerPrefs.GetString("GuterGedanke3");
                }
                if (PlayerPrefs.GetString("ExperimentVersion") == "k")
                {
                    STrainingMainText.text = stringData.sAlternativeGedankenK;//sAlternativeGedankenK;
                    SGedanke1.text = PlayerPrefs.GetString("GuterGedanke1");
                    SGedanke2.text = PlayerPrefs.GetString("GuterGedanke2");
                    SGedanke3.text = PlayerPrefs.GetString("GuterGedanke3");
                }
                SGedanke1Slider.value = fSliderValues[6];
                SGedanke2Slider.value = fSliderValues[7];
                SGedanke3Slider.value = fSliderValues[8];
                /*SGedanke1.text = PlayerPrefs.GetString("GuterGedanke1");
                SGedanke2.text = PlayerPrefs.GetString("GuterGedanke2");
                SGedanke3.text = PlayerPrefs.GetString("GuterGedanke3");*/
                break;
            case 34:
                //btnWeiter.SetActive(true);
                Schwierigkeitstraining.SetActive(false);
                //Kontrollrating.SetActive(true);
                WeiterButtonPressed();
                break;
            case 35:
                //PlayerPrefs.SetString("Kontrollvariable", KontrollValue.text);
                //btnWeiter.SetActive(false);
                /*  if (PlayerPrefs.GetString("ExperimentVersion").Equals("k"))
                  {
                      btnUIWeiter.SetActive(false);
                  }*/
                switch (Cycle)
                {
                    case 0:
                        CreateDataString();
                        fileWriter.data = dataString;
                        fileWriter.SendData();
                        Kontrollrating.SetActive(false);
                        Cycle = 1;
                        Run = 1;
                        ButtonZurück.SetActive(false);
                        fSliderValues[0] = 0;
                        fSliderValues[1] = 0;
                        fSliderValues[2] = 0;
                        fSliderValues[3] = 0;
                        fSliderValues[4] = 0;
                        fSliderValues[5] = 0;
                        fSliderValues[6] = 0;
                        fSliderValues[7] = 0;
                        fSliderValues[8] = 0;
                        StartConfig();
                        break;
                    case 1:
                        CreateDataString();
                        fileWriter.data = dataString;
                        fileWriter.SendData();
                        ButtonZurück.SetActive(false);
                        Kontrollrating.SetActive(false);
                        Verabschiedung.SetActive(true);
                        tVerabschiedung.text = sVerabschiedungNoLink;
                        if (PlayerPrefs.GetString("Mode") == "0")
                        {
                            tVerabschiedung.text = stringData.sVearbschiedung1;
                        }

                        if (PlayerPrefs.GetString("Mode") == "1")
                        {
                            tVerabschiedung.text = stringData.sVearbschiedung2;
                        }


                        if (PlayerPrefs.GetString("Mode") == "2")
                        { 
                            tVerabschiedung.text = stringData.sVearbschiedung3;
                            //LinkButton.SetActive(true);
                        }
                    break;
                }
                break;
        }
    }

    public void ToLimeSurvey()
    {
        //string sUrl = PlayerPrefs.GetString("EndUrl") + PlayerPrefs.GetString("Code") +  "&version=" + PlayerPrefs.GetString("ExperimentVersion");//"https://www.pfh.de/umfragen/index.php/815484/newtest/Y?code=" + PlayerPrefs.GetString("Code");//"https://www.pfh.de/umfragen/index.php/688265/newtest/Y?code=" + PlayerPrefs.GetString("Code");//"https://www.pfh.de/umfragen/index.php/292185/newtest/Y?code=" + PlayerPrefs.GetString("Code");
        //Application.OpenURL(sUrl);
    }

    public void Zurück()
    {
        Run -= 1;
        StartConfig();
    }

    public void ShowSliderValues()
    {
        int temp1 = (int)SGedanke1Slider.value;
        int temp2 = (int)SGedanke2Slider.value;
        int temp3 = (int)SGedanke3Slider.value;
        SGedanke1Value.text = temp1.ToString();
        SGedanke2Value.text = temp2.ToString();
        SGedanke3Value.text = temp3.ToString();
    }

    public void HideUIExplanations()
    {
        btnUIWeiter.SetActive(false);
        Uebungsdurchgang.SetActive(false);
        Durchgang1.SetActive(false);
        Durchgang2.SetActive(false);
        Durchgang3.SetActive(false);
        Durchgang4.SetActive(false);
        Durchgang5.SetActive(false);
        Durchgang6.SetActive(false);
        Durchgang7.SetActive(false);
        Durchgang8.SetActive(false);
        Durchgang9.SetActive(false);
        Durchgang10.SetActive(false);

        if (!PlayerPrefs.GetString("ExperimentVersion").Equals("k")){
            if (Run == 0)
            {
                Run = 1;
                StartConfig();
            }
        }else
        {
            if (Run == 0)
            {
                fSliderValues[0] = 0;
                fSliderValues[1] = 0;
                fSliderValues[2] = 0;
                fSliderValues[3] = 0;
                fSliderValues[4] = 0;
                fSliderValues[5] = 0;
                fSliderValues[6] = 0;
                fSliderValues[7] = 0;
                fSliderValues[8] = 0;
                Run = 32;
                StartConfig();
            }
        }

    }

    public void CreateDataString()
    {
        dataString = System.DateTime.UtcNow.ToString() + ";" + PlayerPrefs.GetString("Studiencode") + ";" + Cycle.ToString() + ";" + PlayerPrefs.GetString("Mode") + ";" + PlayerPrefs.GetString("ExperimentVersion") + ";" + PlayerPrefs.GetString("GuterGedanke1") + ";" + PlayerPrefs.GetString("SchlechterGedanke1") + ";" + PlayerPrefs.GetString("Zustimmung1") +";" + PlayerPrefs.GetString("GuterGedanke2") +
            ";" + PlayerPrefs.GetString("SchlechterGedanke2") + ";" + PlayerPrefs.GetString("Zustimmung2") + ";" + PlayerPrefs.GetString("GuterGedanke3") + ";" + PlayerPrefs.GetString("SchlechterGedanke3") + ";" + PlayerPrefs.GetString("Zustimmung3") + ";";

        /*for (int i = 0; i <31; i++)
        {
            dataString = dataString + fPitch[i].ToString() + ";";
        }*/
        for (int i=0; i<9; i++)
        {
            dataString = dataString + fSliderValues[i].ToString() + ";";
        }
        dataString = dataString + "\n";
    }

}
