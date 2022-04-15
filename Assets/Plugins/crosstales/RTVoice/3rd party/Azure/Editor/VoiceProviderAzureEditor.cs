#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Crosstales.RTVoice.Azure
{
   /// <summary>Custom editor for the 'VoiceProviderAzure'-class.</summary>
   [CustomEditor(typeof(VoiceProviderAzure))]
   public class VoiceProviderAzureEditor : Editor
   {
      #region Variables

      private VoiceProviderAzure script;

      private string apiKey = string.Empty;
      private string endpoint = string.Empty;
      private string requestUri = string.Empty;
      private SampleRate sampleRate = SampleRate._24000Hz;

      #endregion


      #region Properties

      public static bool isPrefabInScene
      {
         get { return GameObject.Find("Azure") != null; }
      }

      #endregion


      #region Editor methods

      public void OnEnable()
      {
         script = (VoiceProviderAzure)target;
      }

      public override void OnInspectorGUI()
      {
         if (GUILayout.Button(new GUIContent(" Learn more", EditorUtil.EditorHelper.Icon_Manual, "Learn more about Azure (Bing Speech).")))
         {
            Util.Helper.OpenURL("https://docs.microsoft.com/en-us/azure/cognitive-services/Speech-Service/");
         }

         GUILayout.Label("Azure Connection", EditorStyles.boldLabel);

         apiKey = EditorGUILayout.PasswordField(new GUIContent("API Key", "API-key to access Azure."), script.APIKey);
         if (!apiKey.Equals(script.APIKey))
         {
            serializedObject.FindProperty("APIKey").stringValue = apiKey;
            serializedObject.ApplyModifiedProperties();
         }

         endpoint = EditorGUILayout.TextField(new GUIContent("Endpoint", "Endpoint to access Azure."), script.Endpoint);
         if (!endpoint.Equals(script.Endpoint))
         {
            serializedObject.FindProperty("Endpoint").stringValue = endpoint;
            serializedObject.ApplyModifiedProperties();
         }

         requestUri = EditorGUILayout.TextField(new GUIContent("Request URI", "Request URI connected with the API-key."), script.RequestUri);
         if (!requestUri.Equals(script.RequestUri))
         {
            serializedObject.FindProperty("RequestUri").stringValue = requestUri;
            serializedObject.ApplyModifiedProperties();
         }

         GUILayout.Space(8);
         GUILayout.Label("Voice Settings", EditorStyles.boldLabel);

         sampleRate = (SampleRate)EditorGUILayout.EnumPopup(new GUIContent("Sample Rate", "Desired sample rate in Hz (default: 24000)."), script.SampleRate);
         if (sampleRate != script.SampleRate)
         {
            serializedObject.FindProperty("SampleRate").enumValueIndex = (int)sampleRate;
            serializedObject.ApplyModifiedProperties();
         }

         //DrawDefaultInspector();

         //EditorHelper.SeparatorUI();

         if (script.isActiveAndEnabled)
         {
            /*
            if (Util.Helper.isIL2CPP && Util.Helper.isAndroidPlatform)
            {
                EditorUtil.EditorHelper.SeparatorUI();
                EditorGUILayout.HelpBox("IL2CPP under Android is not supported by AWS Polly. Please use Mono, MaryTTS or a custom provider (e.g. Klattersynth).", MessageType.Error);
            }
            else 
            */
            if (!script.isPlatformSupported)
            {
               EditorUtil.EditorHelper.SeparatorUI();
               EditorGUILayout.HelpBox("The current platform is not supported by Azure. Please use MaryTTS or a custom provider (e.g. Klattersynth).", MessageType.Error);
            }
            else
            {
               if (script.isValidAPIKey)
               {
                  if (script.isValidRequestUri)
                  {
                     if (script.isValidEndpoint)
                     {
                        //add stuff if needed
                     }
                     else
                     {
                        EditorUtil.EditorHelper.SeparatorUI();
                        EditorGUILayout.HelpBox("Please add a valid 'Endpoint' to access Azure!", MessageType.Warning);
                     }

                  }
                  else
                  {
                     EditorUtil.EditorHelper.SeparatorUI();
                     EditorGUILayout.HelpBox("Please add a valid 'Request URI' to access Azure!", MessageType.Warning);
                  }
               }
               else
               {
                  EditorUtil.EditorHelper.SeparatorUI();
                  EditorGUILayout.HelpBox("Please add a valid 'API Key' to access Azure!", MessageType.Warning);
               }
            }
         }
         else
         {
            EditorUtil.EditorHelper.SeparatorUI();
            EditorGUILayout.HelpBox("Script is disabled!", MessageType.Info);
         }
      }

      #endregion
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)