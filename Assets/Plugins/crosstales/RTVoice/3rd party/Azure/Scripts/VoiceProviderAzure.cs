using UnityEngine;
using System.Collections;
using System.Linq;

namespace Crosstales.RTVoice.Azure
{
   /// <summary>Azure (Bing Speech) voice provider.</summary>
   [HelpURL("https://crosstales.com/media/data/assets/rtvoice/api/class_crosstales_1_1_r_t_voice_1_1_azure_1_1_voice_provider_azure.html")]
   public class VoiceProviderAzure : Provider.BaseCustomVoiceProvider
   {
      #region Variables

      /// <summary>API-key to access Azure.</summary>
      [Header("Azure Connection")] [Tooltip("API-key to access Azure.")] public string APIKey = string.Empty;

      /// <summary>Endpoint to access Azure.</summary>
      [Tooltip("Endpoint to access Azure.")] public string Endpoint = "https://westus.api.cognitive.microsoft.com/sts/v1.0/issueToken";

      /// <summary>Request URI associated with the API-key.</summary>
      [Tooltip("Request URI associated with the API-key.")] public string RequestUri = "https://westus.tts.speech.microsoft.com/cognitiveservices/v1";


      /// <summary>Desired sample rate in Hz (default: 24000).</summary>
      [Header("Voice Settings")] [Tooltip("Desired sample rate in Hz (default: 24000).")] public SampleRate SampleRate = SampleRate._24000Hz;

      private string accessToken;
#if NET_4_6 || NET_STANDARD_2_0
      private bool isReady = false;
#endif

      #endregion


      #region Properties

      public override string AudioFileExtension
      {
         get { return ".wav"; }
      }

      public override AudioType AudioFileType
      {
         get { return AudioType.WAV; }
      }

      public override string DefaultVoiceName
      {
         get { return "JessaRUS"; }
      }

      public override bool isWorkingInEditor
      {
         get { return false; }
      }

      public override bool isWorkingInPlaymode
      {
         get { return true; }
      }

      public override bool isPlatformSupported
      {
         get { return !Util.Helper.isWebPlatform; }
      }

      public override int MaxTextLength
      {
         get { return 256000; }
      }

      public override bool isSpeakNativeSupported
      {
         get { return false; }
      }

      public override bool isSpeakSupported
      {
         get { return true; }
      }

      public override bool isSSMLSupported
      {
         get { return true; }
      }

      public override bool isOnlineService
      {
         get { return true; }
      }

      public override bool hasCoRoutines
      {
         get { return true; }
      }

      public override bool isIL2CPPSupported
      {
         get { return true; }
      }

      public override bool hasVoicesInEditor
      {
         get { return true; }
      }

      /// <summary>Indicates if the API key is valid.</summary>
      /// <returns>True if the API key is valid.</returns>
      public bool isValidAPIKey
      {
         get { return !string.IsNullOrEmpty(APIKey) && APIKey.Length >= 32; }
      }

      /// <summary>Indicates if the endpoint is valid.</summary>
      /// <returns>True if the endpoint is valid.</returns>
      public bool isValidEndpoint
      {
         get { return !string.IsNullOrEmpty(Endpoint) && Endpoint.Contains("api.cognitive.microsoft.com"); }
      }

      /// <summary>Indicates if the request URI is valid.</summary>
      /// <returns>True if the request URI is valid.</returns>
      public bool isValidRequestUri
      {
         get { return !string.IsNullOrEmpty(RequestUri) && RequestUri.Contains("tts.speech.microsoft.com"); }
      }

      #endregion


      #region Implemented methods

      public override void Load()
      {
         System.Collections.Generic.List<Model.Voice> voices = new System.Collections.Generic.List<Model.Voice>
         {
            new Model.Voice("Hoda", "Microsoft Server Speech Text to Speech Voice (ar-EG, Hoda)", Model.Enum.Gender.FEMALE, "adult", "ar-EG", "Microsoft Server Speech Text to Speech Voice (ar-EG, Hoda)"),
            new Model.Voice("Naayf", "Microsoft Server Speech Text to Speech Voice (ar-SA, Naayf)", Model.Enum.Gender.MALE, "adult", "ar-SA", "Microsoft Server Speech Text to Speech Voice (ar-SA, Naayf)"),
            new Model.Voice("Ivan", "Microsoft Server Speech Text to Speech Voice (bg-BG, Ivan)", Model.Enum.Gender.MALE, "adult", "bg-BG", "Microsoft Server Speech Text to Speech Voice (bg-BG, Ivan)"),
            new Model.Voice("HerenaRUS", "Microsoft Server Speech Text to Speech Voice (ca-ES, HerenaRUS)", Model.Enum.Gender.FEMALE, "adult", "ca-ES", "Microsoft Server Speech Text to Speech Voice (ca-ES, HerenaRUS)"),
            new Model.Voice("Jakub", "Microsoft Server Speech Text to Speech Voice (cs-CZ, Jakub)", Model.Enum.Gender.MALE, "adult", "cs-CZ", "Microsoft Server Speech Text to Speech Voice (cs-CZ, Jakub)"),
            new Model.Voice("HelleRUS", "Microsoft Server Speech Text to Speech Voice (da-DK, HelleRUS)", Model.Enum.Gender.FEMALE, "adult", "da-DK", "Microsoft Server Speech Text to Speech Voice (da-DK, HelleRUS)"),
            new Model.Voice("Michael", "Microsoft Server Speech Text to Speech Voice (de-AT, Michael)", Model.Enum.Gender.MALE, "adult", "de-AT", "Microsoft Server Speech Text to Speech Voice (de-AT, Michael)"),
            new Model.Voice("Karsten", "Microsoft Server Speech Text to Speech Voice (de-CH, Karsten)", Model.Enum.Gender.MALE, "adult", "de-CH", "Microsoft Server Speech Text to Speech Voice (de-CH, Karsten)"),
            new Model.Voice("Hedda", "Microsoft Server Speech Text to Speech Voice (de-DE, Hedda)", Model.Enum.Gender.FEMALE, "adult", "de-DE", "Microsoft Server Speech Text to Speech Voice (de-DE, Hedda)"),
            new Model.Voice("HeddaRUS", "Microsoft Server Speech Text to Speech Voice (de-DE, HeddaRUS)", Model.Enum.Gender.FEMALE, "adult", "de-DE", "Microsoft Server Speech Text to Speech Voice (de-DE, HeddaRUS)"),
            new Model.Voice("Stefan-Apollo", "Microsoft Server Speech Text to Speech Voice (de-DE, Stefan, Apollo)", Model.Enum.Gender.MALE, "adult", "de-DE", "Microsoft Server Speech Text to Speech Voice (de-DE, Stefan, Apollo)"),
            new Model.Voice("Stefanos", "Microsoft Server Speech Text to Speech Voice (el-GR, Stefanos)", Model.Enum.Gender.MALE, "adult", "el-GR", "Microsoft Server Speech Text to Speech Voice (el-GR, Stefanos)"),
            new Model.Voice("Catherine", "Microsoft Server Speech Text to Speech Voice (en-AU, Catherine)", Model.Enum.Gender.FEMALE, "adult", "en-AU", "Microsoft Server Speech Text to Speech Voice (en-AU, Catherine)"),
            new Model.Voice("HayleyRUS", "Microsoft Server Speech Text to Speech Voice (en-AU, HayleyRUS)", Model.Enum.Gender.FEMALE, "adult", "en-AU", "Microsoft Server Speech Text to Speech Voice (en-AU, HayleyRUS)"),
            new Model.Voice("Linda", "Microsoft Server Speech Text to Speech Voice (en-CA, Linda)", Model.Enum.Gender.FEMALE, "adult", "en-CA", "Microsoft Server Speech Text to Speech Voice (en-CA, Linda)"),
            new Model.Voice("HeatherRUS", "Microsoft Server Speech Text to Speech Voice (en-CA, HeatherRUS)", Model.Enum.Gender.FEMALE, "adult", "en-CA", "Microsoft Server Speech Text to Speech Voice (en-CA, HeatherRUS)"),
            new Model.Voice("Susan-Apollo", "Microsoft Server Speech Text to Speech Voice (en-GB, Susan, Apollo)", Model.Enum.Gender.FEMALE, "adult", "en-GB", "Microsoft Server Speech Text to Speech Voice (en-GB, Susan, Apollo)"),
            new Model.Voice("HazelRUS", "Microsoft Server Speech Text to Speech Voice (en-GB, HazelRUS)", Model.Enum.Gender.FEMALE, "adult", "en-GB", "Microsoft Server Speech Text to Speech Voice (en-GB, HazelRUS)"),
            new Model.Voice("George-Apollo", "Microsoft Server Speech Text to Speech Voice (en-GB, George, Apollo)", Model.Enum.Gender.MALE, "adult", "en-GB", "Microsoft Server Speech Text to Speech Voice (en-GB, George, Apollo)"),
            new Model.Voice("Sean", "Microsoft Server Speech Text to Speech Voice (en-IE, Sean)", Model.Enum.Gender.MALE, "adult", "en-IE", "Microsoft Server Speech Text to Speech Voice (en-IE, Sean)"),
            new Model.Voice("Heera-Apollo", "Microsoft Server Speech Text to Speech Voice (en-IN, Heera, Apollo)", Model.Enum.Gender.FEMALE, "adult", "en-IN", "Microsoft Server Speech Text to Speech Voice (en-IN, Heera, Apollo)"),
            new Model.Voice("PriyaRUS", "Microsoft Server Speech Text to Speech Voice (en-IN, PriyaRUS)", Model.Enum.Gender.FEMALE, "adult", "en-IN", "Microsoft Server Speech Text to Speech Voice (en-IN, PriyaRUS)"),
            new Model.Voice("Ravi-Apollo", "Microsoft Server Speech Text to Speech Voice (en-IN, Ravi, Apollo)", Model.Enum.Gender.MALE, "adult", "en-IN", "Microsoft Server Speech Text to Speech Voice (en-IN, Ravi, Apollo)"),
            new Model.Voice("ZiraRUS", "Microsoft Server Speech Text to Speech Voice (en-US, ZiraRUS)", Model.Enum.Gender.FEMALE, "adult", "en-US", "Microsoft Server Speech Text to Speech Voice (en-US, ZiraRUS)"),
            new Model.Voice("JessaRUS", "Microsoft Server Speech Text to Speech Voice (en-US, JessaRUS)", Model.Enum.Gender.FEMALE, "adult", "en-US", "Microsoft Server Speech Text to Speech Voice (en-US, JessaRUS)"),
            new Model.Voice("BenjaminRUS", "Microsoft Server Speech Text to Speech Voice (en-US, BenjaminRUS)", Model.Enum.Gender.MALE, "adult", "en-US", "Microsoft Server Speech Text to Speech Voice (en-US, BenjaminRUS)"),
            new Model.Voice("Jessa24kRUS", "Microsoft Server Speech Text to Speech Voice (en-US, Jessa24kRUS)", Model.Enum.Gender.FEMALE, "adult", "en-US", "Microsoft Server Speech Text to Speech Voice (en-US, Jessa24kRUS)"),
            new Model.Voice("Guy24kRUS", "Microsoft Server Speech Text to Speech Voice (en-US, Guy24kRUS)", Model.Enum.Gender.MALE, "adult", "en-US", "Microsoft Server Speech Text to Speech Voice (en-US, Guy24kRUS)"),
            new Model.Voice("Laura-Apollo", "Microsoft Server Speech Text to Speech Voice (es-ES, Laura, Apollo)", Model.Enum.Gender.FEMALE, "adult", "es-ES", "Microsoft Server Speech Text to Speech Voice (es-ES, Laura, Apollo)"),
            new Model.Voice("HelenaRUS", "Microsoft Server Speech Text to Speech Voice (es-ES, HelenaRUS)", Model.Enum.Gender.FEMALE, "adult", "es-ES", "Microsoft Server Speech Text to Speech Voice (es-ES, HelenaRUS)"),
            new Model.Voice("Pablo-Apollo", "Microsoft Server Speech Text to Speech Voice (es-ES, Pablo, Apollo)", Model.Enum.Gender.MALE, "adult", "es-ES", "Microsoft Server Speech Text to Speech Voice (es-ES, Pablo, Apollo)"),
            new Model.Voice("HildaRUS", "Microsoft Server Speech Text to Speech Voice (es-MX, HildaRUS)", Model.Enum.Gender.FEMALE, "adult", "es-MX", "Microsoft Server Speech Text to Speech Voice (es-MX, HildaRUS)"),
            new Model.Voice("Raul-Apollo", "Microsoft Server Speech Text to Speech Voice (es-MX, Raul, Apollo)", Model.Enum.Gender.MALE, "adult", "es-MX", "Microsoft Server Speech Text to Speech Voice (es-MX, Raul, Apollo)"),
            new Model.Voice("HeidiRUS", "Microsoft Server Speech Text to Speech Voice (fi-FI, HeidiRUS)", Model.Enum.Gender.FEMALE, "adult", "fi-FI", "Microsoft Server Speech Text to Speech Voice (fi-FI, HeidiRUS)"),
            new Model.Voice("Caroline", "Microsoft Server Speech Text to Speech Voice (fr-CA, Caroline)", Model.Enum.Gender.FEMALE, "adult", "fr-CA", "Microsoft Server Speech Text to Speech Voice (fr-CA, Caroline)"),
            new Model.Voice("HarmonieRUS", "Microsoft Server Speech Text to Speech Voice (fr-CA, HarmonieRUS)", Model.Enum.Gender.FEMALE, "adult", "fr-CA", "Microsoft Server Speech Text to Speech Voice (fr-CA, HarmonieRUS)"),
            new Model.Voice("Guillaume", "Microsoft Server Speech Text to Speech Voice (fr-CH, Guillaume)", Model.Enum.Gender.MALE, "adult", "fr-CH", "Microsoft Server Speech Text to Speech Voice (fr-CH, Guillaume)"),
            new Model.Voice("Julie-Apollo", "Microsoft Server Speech Text to Speech Voice (fr-FR, Julie, Apollo)", Model.Enum.Gender.FEMALE, "adult", "fr-FR", "Microsoft Server Speech Text to Speech Voice (fr-FR, Julie, Apollo)"),
            new Model.Voice("HortenseRUS", "Microsoft Server Speech Text to Speech Voice (fr-FR, HortenseRUS)", Model.Enum.Gender.FEMALE, "adult", "fr-FR", "Microsoft Server Speech Text to Speech Voice (fr-FR, HortenseRUS)"),
            new Model.Voice("Paul-Apollo", "Microsoft Server Speech Text to Speech Voice (fr-FR, Paul, Apollo)", Model.Enum.Gender.MALE, "adult", "fr-FR", "Microsoft Server Speech Text to Speech Voice (fr-FR, Paul, Apollo)"),
            new Model.Voice("Asaf", "Microsoft Server Speech Text to Speech Voice (he-IL, Asaf)", Model.Enum.Gender.MALE, "adult", "he-IL", "Microsoft Server Speech Text to Speech Voice (he-IL, Asaf)"),
            new Model.Voice("Kalpana-Apollo", "Microsoft Server Speech Text to Speech Voice (hi-IN, Kalpana, Apollo)", Model.Enum.Gender.FEMALE, "adult", "hi-IN", "Microsoft Server Speech Text to Speech Voice (hi-IN, Kalpana, Apollo)"),
            new Model.Voice("Kalpana", "Microsoft Server Speech Text to Speech Voice (hi-IN, Kalpana)", Model.Enum.Gender.FEMALE, "adult", "hi-IN", "Microsoft Server Speech Text to Speech Voice (hi-IN, Kalpana)"),
            new Model.Voice("Hemant", "Microsoft Server Speech Text to Speech Voice (hi-IN, Hemant)", Model.Enum.Gender.MALE, "adult", "hi-IN", "Microsoft Server Speech Text to Speech Voice (hi-IN, Hemant)"),
            new Model.Voice("Matej", "Microsoft Server Speech Text to Speech Voice (hr-HR, Matej)", Model.Enum.Gender.MALE, "adult", "hr-HR", "Microsoft Server Speech Text to Speech Voice (hr-HR, Matej)"),
            new Model.Voice("Szabolcs", "Microsoft Server Speech Text to Speech Voice (hu-HU, Szabolcs)", Model.Enum.Gender.MALE, "adult", "hu-HU", "Microsoft Server Speech Text to Speech Voice (hu-HU, Szabolcs)"),
            new Model.Voice("Andika", "Microsoft Server Speech Text to Speech Voice (id-ID, Andika)", Model.Enum.Gender.MALE, "adult", "id-ID", "Microsoft Server Speech Text to Speech Voice (id-ID, Andika)"),
            new Model.Voice("Cosimo-Apollo", "Microsoft Server Speech Text to Speech Voice (it-IT, Cosimo, Apollo)", Model.Enum.Gender.MALE, "adult", "it-IT", "Microsoft Server Speech Text to Speech Voice (it-IT, Cosimo, Apollo)"),
            new Model.Voice("LuciaRUS", "Microsoft Server Speech Text to Speech Voice (it-IT, LuciaRUS)", Model.Enum.Gender.FEMALE, "adult", "it-IT", "Microsoft Server Speech Text to Speech Voice (it-IT, LuciaRUS)"),
            new Model.Voice("Ayumi-Apollo", "Microsoft Server Speech Text to Speech Voice (ja-JP, Ayumi, Apollo)", Model.Enum.Gender.FEMALE, "adult", "ja-JP", "Microsoft Server Speech Text to Speech Voice (ja-JP, Ayumi, Apollo)"),
            new Model.Voice("Ichiro-Apollo", "Microsoft Server Speech Text to Speech Voice (ja-JP, Ichiro, Apollo)", Model.Enum.Gender.MALE, "adult", "ja-JP", "Microsoft Server Speech Text to Speech Voice (ja-JP, Ichiro, Apollo)"),
            new Model.Voice("HarukaRUS", "Microsoft Server Speech Text to Speech Voice (ja-JP, HarukaRUS)", Model.Enum.Gender.FEMALE, "adult", "ja-JP", "Microsoft Server Speech Text to Speech Voice (ja-JP, HarukaRUS)"),
            new Model.Voice("HeamiRUS", "Microsoft Server Speech Text to Speech Voice (ko-KR, HeamiRUS)", Model.Enum.Gender.FEMALE, "adult", "ko-KR", "Microsoft Server Speech Text to Speech Voice (ko-KR, HeamiRUS)"),
            new Model.Voice("Rizwan", "Microsoft Server Speech Text to Speech Voice (ms-MY, Rizwan)", Model.Enum.Gender.MALE, "adult", "ms-MY", "Microsoft Server Speech Text to Speech Voice (ms-MY, Rizwan)"),
            new Model.Voice("HuldaRUS", "Microsoft Server Speech Text to Speech Voice (nb-NO, HuldaRUS)", Model.Enum.Gender.FEMALE, "adult", "nb-NO", "Microsoft Server Speech Text to Speech Voice (nb-NO, HuldaRUS)"),
            new Model.Voice("HannaRUS", "Microsoft Server Speech Text to Speech Voice (nl-NL, HannaRUS)", Model.Enum.Gender.FEMALE, "adult", "nl-NL", "Microsoft Server Speech Text to Speech Voice (nl-NL, HannaRUS)"),
            new Model.Voice("PaulinaRUS", "Microsoft Server Speech Text to Speech Voice (pl-PL, PaulinaRUS)", Model.Enum.Gender.FEMALE, "adult", "pl-PL", "Microsoft Server Speech Text to Speech Voice (pl-PL, PaulinaRUS)"),
            new Model.Voice("HeloisaRUS", "Microsoft Server Speech Text to Speech Voice (pt-BR, HeloisaRUS)", Model.Enum.Gender.FEMALE, "adult", "pt-BR", "Microsoft Server Speech Text to Speech Voice (pt-BR, HeloisaRUS)"),
            new Model.Voice("Daniel-Apollo", "Microsoft Server Speech Text to Speech Voice (pt-BR, Daniel, Apollo)", Model.Enum.Gender.MALE, "adult", "pt-BR", "Microsoft Server Speech Text to Speech Voice (pt-BR, Daniel, Apollo)"),
            new Model.Voice("HeliaRUS", "Microsoft Server Speech Text to Speech Voice (pt-PT, HeliaRUS)", Model.Enum.Gender.FEMALE, "adult", "pt-PT", "Microsoft Server Speech Text to Speech Voice (pt-PT, HeliaRUS)"),
            new Model.Voice("Andrei", "Microsoft Server Speech Text to Speech Voice (ro-RO, Andrei)", Model.Enum.Gender.MALE, "adult", "ro-RO", "Microsoft Server Speech Text to Speech Voice (ro-RO, Andrei)"),
            new Model.Voice("Irina-Apollo", "Microsoft Server Speech Text to Speech Voice (ru-RU, Irina, Apollo)", Model.Enum.Gender.FEMALE, "adult", "ru-RU", "Microsoft Server Speech Text to Speech Voice (ru-RU, Irina, Apollo)"),
            new Model.Voice("Pavel-Apollo", "Microsoft Server Speech Text to Speech Voice (ru-RU, Pavel, Apollo)", Model.Enum.Gender.MALE, "adult", "ru-RU", "Microsoft Server Speech Text to Speech Voice (ru-RU, Pavel, Apollo)"),
            new Model.Voice("EkaterinaRUS", "Microsoft Server Speech Text to Speech Voice (ru-RU, EkaterinaRUS)", Model.Enum.Gender.FEMALE, "adult", "ru-RU", "Microsoft Server Speech Text to Speech Voice (ru-RU, EkaterinaRUS)"),
            new Model.Voice("Filip", "Microsoft Server Speech Text to Speech Voice (sk-SK, Filip)", Model.Enum.Gender.MALE, "adult", "sk-SK", "Microsoft Server Speech Text to Speech Voice (sk-SK, Filip)"),
            new Model.Voice("Lado", "Microsoft Server Speech Text to Speech Voice (sl-SI, Lado)", Model.Enum.Gender.MALE, "adult", "sl-SI", "Microsoft Server Speech Text to Speech Voice (sl-SI, Lado)"),
            new Model.Voice("HedvigRUS", "Microsoft Server Speech Text to Speech Voice (sv-SE, HedvigRUS)", Model.Enum.Gender.FEMALE, "adult", "sv-SE", "Microsoft Server Speech Text to Speech Voice (sv-SE, HedvigRUS)"),
            new Model.Voice("Valluvar", "Microsoft Server Speech Text to Speech Voice (ta-IN, Valluvar)", Model.Enum.Gender.MALE, "adult", "ta-IN", "Microsoft Server Speech Text to Speech Voice (ta-IN, Valluvar)"),
            new Model.Voice("Chitra", "Microsoft Server Speech Text to Speech Voice (te-IN, Chitra)", Model.Enum.Gender.FEMALE, "adult", "te-IN", "Microsoft Server Speech Text to Speech Voice (te-IN, Chitra)"),
            new Model.Voice("Pattara", "Microsoft Server Speech Text to Speech Voice (th-TH, Pattara)", Model.Enum.Gender.MALE, "adult", "th-TH", "Microsoft Server Speech Text to Speech Voice (th-TH, Pattara)"),
            new Model.Voice("SedaRUS", "Microsoft Server Speech Text to Speech Voice (tr-TR, SedaRUS)", Model.Enum.Gender.FEMALE, "adult", "tr-TR", "Microsoft Server Speech Text to Speech Voice (tr-TR, SedaRUS)"),
            new Model.Voice("An", "Microsoft Server Speech Text to Speech Voice (vi-VN, An)", Model.Enum.Gender.MALE, "adult", "vi-VN", "Microsoft Server Speech Text to Speech Voice (vi-VN, An)"),
            new Model.Voice("HuihuiRUS", "Microsoft Server Speech Text to Speech Voice (zh-CN, HuihuiRUS)", Model.Enum.Gender.FEMALE, "adult", "zh-CN", "Microsoft Server Speech Text to Speech Voice (zh-CN, HuihuiRUS)"),
            new Model.Voice("Yaoyao-Apollo", "Microsoft Server Speech Text to Speech Voice (zh-CN, Yaoyao, Apollo)", Model.Enum.Gender.FEMALE, "adult", "zh-CN", "Microsoft Server Speech Text to Speech Voice (zh-CN, Yaoyao, Apollo)"),
            new Model.Voice("Kangkang-Apollo", "Microsoft Server Speech Text to Speech Voice (zh-CN, Kangkang, Apollo)", Model.Enum.Gender.MALE, "adult", "zh-CN", "Microsoft Server Speech Text to Speech Voice (zh-CN, Kangkang, Apollo)"),
            new Model.Voice("Tracy-Apollo", "Microsoft Server Speech Text to Speech Voice (zh-HK, Tracy, Apollo)", Model.Enum.Gender.FEMALE, "adult", "zh-HK", "Microsoft Server Speech Text to Speech Voice (zh-HK, Tracy, Apollo)"),
            new Model.Voice("TracyRUS", "Microsoft Server Speech Text to Speech Voice (zh-HK, TracyRUS)", Model.Enum.Gender.FEMALE, "adult", "zh-HK", "Microsoft Server Speech Text to Speech Voice (zh-HK, TracyRUS)"),
            new Model.Voice("Danny-Apollo", "Microsoft Server Speech Text to Speech Voice (zh-HK, Danny, Apollo)", Model.Enum.Gender.MALE, "adult", "zh-HK", "Microsoft Server Speech Text to Speech Voice (zh-HK, Danny, Apollo)"),
            new Model.Voice("Yating-Apollo", "Microsoft Server Speech Text to Speech Voice (zh-TW, Yating, Apollo)", Model.Enum.Gender.FEMALE, "adult", "zh-TW", "Microsoft Server Speech Text to Speech Voice (zh-TW, Yating, Apollo)"),
            new Model.Voice("HanHanRUS", "Microsoft Server Speech Text to Speech Voice (zh-TW, HanHanRUS)", Model.Enum.Gender.FEMALE, "adult", "zh-TW", "Microsoft Server Speech Text to Speech Voice (zh-TW, HanHanRUS)"),
            new Model.Voice("Zhiwei-Apollo", "Microsoft Server Speech Text to Speech Voice (zh-TW, Zhiwei, Apollo)", Model.Enum.Gender.MALE, "adult", "zh-TW", "Microsoft Server Speech Text to Speech Voice (zh-TW, Zhiwei, Apollo)")
            //new Model.Voice("KatjaNeural","Microsoft Server Speech Text to Speech Voice (de-DE, KatjaNeural)",Model.Enum.Gender.FEMALE,"adult","de-DE","Microsoft Server Speech Text to Speech Voice (de-DE, KatjaNeural)"),
            //new Model.Voice("GuyNeural","Microsoft Server Speech Text to Speech Voice (en-US, GuyNeural)",Model.Enum.Gender.MALE,"adult","en-US","Microsoft Server Speech Text to Speech Voice (en-US, GuyNeural)"),
            //new Model.Voice("JessaNeural","Microsoft Server Speech Text to Speech Voice (en-US, JessaNeural)",Model.Enum.Gender.FEMALE,"adult","en-US","Microsoft Server Speech Text to Speech Voice (en-US, JessaNeural)"),
            //new Model.Voice("ElsaNeural","Microsoft Server Speech Text to Speech Voice (it-IT, ElsaNeural)",Model.Enum.Gender.FEMALE,"adult","it-IT","Microsoft Server Speech Text to Speech Voice (it-IT, ElsaNeural)"),
            //new Model.Voice("XiaoxiaoNeural","Microsoft Server Speech Text to Speech Voice (zh-CN, XiaoxiaoNeural)",Model.Enum.Gender.FEMALE,"adult","zh-CN","Microsoft Server Speech Text to Speech Voice (zh-CN, XiaoxiaoNeural)"),
         };
#if NET_4_6 || NET_STANDARD_2_0
         isReady = false;
#endif
         cachedVoices = voices.OrderBy(s => s.Name).ToList();

         onVoicesReady();
      }

      public override IEnumerator Generate(Model.Wrapper wrapper)
      {
#if !UNITY_WEBGL
#if NET_4_6 || NET_STANDARD_2_0
         if (!isReady)
            yield return connect(wrapper);

         if (!isReady)
         {
            Debug.LogWarning("Not connected to Azure! Did you enter the correct API-key?", this);
         }
         else
         {
            if (wrapper == null)
            {
               Debug.LogWarning("'wrapper' is null!", this);
            }
            else
            {
               if (string.IsNullOrEmpty(wrapper.Text))
               {
                  Debug.LogWarning("'wrapper.Text' is null or empty!", this);
               }
               else
               {
                  if (!Util.Helper.isInternetAvailable)
                  {
                     const string errorMessage = "Internet is not available - can't use Azure right now!";
                     Debug.LogError(errorMessage, this);
                     onErrorInfo(wrapper, errorMessage);
                  }
                  else
                  {
                     yield return null; //return to the main process (uid)
                     silence = false;
                     bool success = false;

                     onSpeakAudioGenerationStart(wrapper);

                     Synthesize cortana = new Synthesize();
                     string outputFile = getOutputFile(wrapper.Uid, Common.Util.BaseHelper.isWebPlatform);

                     System.Threading.Tasks.Task<System.IO.Stream> speakTask = cortana.Speak(System.Threading.CancellationToken.None, new Synthesize.InputOptions
                     {
                        RequestUri = new System.Uri(RequestUri),

                        Text = prepareText(wrapper),
                        VoiceType = getVoiceGender(wrapper),
                        Locale = getVoiceCulture(wrapper),
                        VoiceName = getVoiceID(wrapper),
                        OutputFormat = SampleRate == SampleRate._16000Hz ? AudioOutputFormat.Riff16Khz16BitMonoPcm : AudioOutputFormat.Riff24Khz16BitMonoPcm,
                        AuthorizationToken = "Bearer " + accessToken
                     });

                     do
                     {
                        yield return null;
                     } while (!speakTask.IsCompleted);

                     try
                     {
                        System.IO.File.WriteAllBytes(outputFile, speakTask.Result.CTReadFully());
                        success = true;
                     }
                     catch (System.Exception ex)
                     {
                        string errorMessage = "Could not create output file: " + outputFile + System.Environment.NewLine + "Error: " + ex;
                        Debug.LogError(errorMessage, this);
                        onErrorInfo(wrapper, errorMessage);
                     }

                     if (success)
                        processAudioFile(wrapper, outputFile);
                  }
               }
            }
         }
#else
         Debug.LogError("'Generate' is only supported in .NET4.x or .NET Standard 2.0!", this);
         yield return null;
#endif
#else
         Debug.LogError("'Generate' is not supported under WebGL!", this);
         yield return null;
#endif
      }

      public override IEnumerator SpeakNative(Model.Wrapper wrapper)
      {
#if NET_4_6 || NET_STANDARD_2_0
         yield return speak(wrapper, true);
#else
         Debug.LogError("'SpeakNative' is only supported in .NET4.x or .NET Standard 2.0!", this);
         yield return null;
#endif
      }

      public override IEnumerator Speak(Model.Wrapper wrapper)
      {
#if NET_4_6 || NET_STANDARD_2_0
         yield return speak(wrapper, false);
#else
         Debug.LogError("'Speak' is only supported in .NET4.x or .NET Standard 2.0!", this);
         yield return null;
#endif
      }

      #endregion


      #region Private methods

#if NET_4_6 || NET_STANDARD_2_0
      private IEnumerator connect(Model.Wrapper wrapper)
      {
         isReady = false;

         if (!isValidAPIKey)
         {
            string errorMessage = "Please add a valid 'API Key' to access Azure!";
            Debug.LogError(errorMessage, this);
            onErrorInfo(wrapper, errorMessage);
         }
         else if (!isValidRequestUri)
         {
            string errorMessage = "Please add a valid 'Request URI' to access Azure!";
            Debug.LogError(errorMessage, this);
            onErrorInfo(wrapper, errorMessage);
         }
         else if (!isValidEndpoint)
         {
            string errorMessage = "Please add a valid 'Endpoint' to access Azure!";
            Debug.LogError(errorMessage, this);
            onErrorInfo(wrapper, errorMessage);
         }
         else
         {
#if !UNITY_WSA || UNITY_EDITOR
            System.Net.ServicePointManager.ServerCertificateValidationCallback = Common.Util.BaseHelper.RemoteCertificateValidationCallback;
#endif
            Authentication auth = new Authentication();
            System.Threading.Tasks.Task<string> authenticating = auth.Authenticate(Endpoint, APIKey);

            yield return authenticateSpeechService(authenticating);
         }
      }

      private IEnumerator authenticateSpeechService(System.Threading.Tasks.Task<string> authenticating)
      {
         // Yield control back to the main thread as long as the task is still running
         while (!authenticating.IsCompleted)
         {
            yield return null;
         }

         try
         {
            accessToken = authenticating.Result;

            isReady = true;

            if (string.IsNullOrEmpty(accessToken))
            {
               isReady = false;
               Debug.LogError("No valid token received; are the settings for Azure correct?", this);
            }
            else if (accessToken.Contains("error"))
            {
               isReady = false;
               Debug.LogError("No valid token received: " + accessToken, this);
            }

            if (Util.Config.DEBUG)
               Debug.Log("Token: " + accessToken, this);
         }
         catch (System.Exception ex)
         {
            Debug.LogError("Failed authentication: " + ex, this);
         }
      }

      private IEnumerator speak(Model.Wrapper wrapper, bool isNative)
      {
         if (!isReady)
            yield return connect(wrapper);

         if (!isReady)
         {
            Debug.LogWarning("Not connected to Azure! Did you enter the correct API-key?", this);
         }
         else
         {
            if (wrapper == null)
            {
               Debug.LogWarning("'wrapper' is null!", this);
            }
            else
            {
               if (string.IsNullOrEmpty(wrapper.Text))
               {
                  Debug.LogWarning("'wrapper.Text' is null or empty!", this);
               }
               else
               {
                  if (!Common.Util.BaseHelper.isInternetAvailable)
                  {
                     const string errorMessage = "Internet is not available - can't use Azure right now!";
                     Debug.LogError(errorMessage, this);
                     onErrorInfo(wrapper, errorMessage);
                  }
                  else
                  {
                     yield return null; //return to the main process (uid)
                     silence = false;
                     bool success = false;

                     if (!isNative)
                        onSpeakAudioGenerationStart(wrapper);

                     Synthesize cortana = new Synthesize();
                     string outputFile = getOutputFile(wrapper.Uid, Util.Helper.isWebPlatform);

                     System.Threading.Tasks.Task<System.IO.Stream> speakTask = cortana.Speak(System.Threading.CancellationToken.None, new Synthesize.InputOptions
                     {
                        RequestUri = new System.Uri(RequestUri),

                        Text = prepareText(wrapper),
                        VoiceType = getVoiceGender(wrapper),
                        Locale = getVoiceCulture(wrapper),
                        VoiceName = getVoiceID(wrapper),
                        OutputFormat = SampleRate == SampleRate._16000Hz ? AudioOutputFormat.Riff16Khz16BitMonoPcm : AudioOutputFormat.Riff24Khz16BitMonoPcm,
                        AuthorizationToken = "Bearer " + accessToken
                     });

                     do
                     {
                        yield return null;
                     } while (!speakTask.IsCompleted);
#if UNITY_WEBGL
                     AudioClip ac = Util.WavMaster.ToAudioClip(speakTask.Result.CTReadFully());
                     yield return playAudioFile(wrapper, ac, isNative);
                     Destroy(ac);
#else
                     try
                     {
                        System.IO.File.WriteAllBytes(outputFile, speakTask.Result.CTReadFully());
                        success = true;
                     }
                     catch (System.Exception ex)
                     {
                        string errorMessage = "Could not create output file: " + outputFile + System.Environment.NewLine + "Error: " + ex;
                        Debug.LogError(errorMessage, this);
                        onErrorInfo(wrapper, errorMessage);
                     }

                     if (success)
                        yield return playAudioFile(wrapper, Util.Helper.ValidURLFromFilePath(outputFile), outputFile, AudioFileType, isNative);
#endif
                  }
               }
            }
         }
      }

      private string getVoiceID(Model.Wrapper wrapper)
      {
         if (wrapper != null && (wrapper.Voice == null || string.IsNullOrEmpty(wrapper.Voice.Identifier)))
         {
            if (Util.Config.DEBUG)
               Debug.LogWarning("'wrapper.Voice' or 'wrapper.Voice.Identifier' is null! Using the OS 'default' voice.", this);

            return Speaker.VoiceForName(DefaultVoiceName).Identifier;
         }

         return wrapper != null ? wrapper.Voice.Identifier : Speaker.VoiceForName(DefaultVoiceName).Identifier;
      }

      private string getVoiceCulture(Model.Wrapper wrapper)
      {
         if (wrapper.Voice == null || string.IsNullOrEmpty(wrapper.Voice.Culture))
         {
            if (Util.Config.DEBUG)
               Debug.LogWarning("'wrapper.Voice' or 'wrapper.Voice.Culture' is null! Using the 'default' English voice.", this);

            //always use English as fallback
            return "en-US";
         }

         return wrapper.Voice.Culture;
      }

      private Model.Enum.Gender getVoiceGender(Model.Wrapper wrapper)
      {
         if (wrapper.Voice == null)
         {
            if (Util.Config.DEBUG)
               Debug.LogWarning("'wrapper.Voice' is null! Using the 'default' Female voice.", this);

            //always use a Female voice as fallback
            return Model.Enum.Gender.FEMALE;
         }

         return wrapper.Voice.Gender;
      }

      private static string prepareText(Model.Wrapper wrapper)
      {
         if (Mathf.Abs(wrapper.Rate - 1f) > Common.Util.BaseConstants.FLOAT_TOLERANCE || Mathf.Abs(wrapper.Pitch - 1f) > Common.Util.BaseConstants.FLOAT_TOLERANCE || Mathf.Abs(wrapper.Volume - 1f) > Common.Util.BaseConstants.FLOAT_TOLERANCE)
         {
            System.Text.StringBuilder sbXML = new System.Text.StringBuilder();

            sbXML.Append("<prosody");

            if (Mathf.Abs(wrapper.Rate - 1f) > Common.Util.BaseConstants.FLOAT_TOLERANCE)
            {
               float _rate = wrapper.Rate > 1 ? (wrapper.Rate - 1f) * 0.5f : wrapper.Rate - 1f;

               sbXML.Append(" rate=\"");
               sbXML.Append(_rate >= 0f
                  ? _rate.ToString("+#0%", Util.Helper.BaseCulture)
                  : _rate.ToString("#0%", Util.Helper.BaseCulture));

               sbXML.Append("\"");
            }

            if (Mathf.Abs(wrapper.Pitch - 1f) > Common.Util.BaseConstants.FLOAT_TOLERANCE)
            {
               float _pitch = wrapper.Pitch - 1f;

               sbXML.Append(" pitch=\"");
               sbXML.Append(_pitch >= 0f
                  ? _pitch.ToString("+#0%", Util.Helper.BaseCulture)
                  : _pitch.ToString("#0%", Util.Helper.BaseCulture));

               sbXML.Append("\"");
            }

            if (Mathf.Abs(wrapper.Volume - 1f) > Common.Util.BaseConstants.FLOAT_TOLERANCE)
            {
               sbXML.Append(" volume=\"");
               sbXML.Append((100 * wrapper.Volume).ToString("#0", Util.Helper.BaseCulture));

               sbXML.Append("\"");
            }

            sbXML.Append(">");

            sbXML.Append(wrapper.Text);

            sbXML.Append("</prosody>");

            return getValidXML(sbXML.ToString());
         }

         return getValidXML(wrapper.Text);
      }
#endif

      #endregion


      #region Editor-only methods

#if UNITY_EDITOR
      public override void GenerateInEditor(Model.Wrapper wrapper)
      {
         Debug.LogError("'GenerateInEditor' is not supported for Azure!", this);
      }

      public override void SpeakNativeInEditor(Model.Wrapper wrapper)
      {
         Debug.LogError("'SpeakNativeInEditor' is not supported for Azure!", this);
      }
#endif

      #endregion
   }
}
// © 2019-2020 crosstales LLC (https://www.crosstales.com)