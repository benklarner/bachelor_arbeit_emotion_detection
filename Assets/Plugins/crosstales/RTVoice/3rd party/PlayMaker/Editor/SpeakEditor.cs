#if PLAYMAKER && UNITY_EDITOR
using UnityEngine;
//using UnityEditor;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

namespace Crosstales.RTVoice.PlayMaker
{
   /// <summary>Custom editor for the Speak-action.</summary>
   [CustomActionEditor(typeof(Speak))]
   public class SpeakEditor : CustomActionEditor
   {
      private Speak action;
      //private bool reset = false;

      public override void OnEnable()
      {
         action = target as Speak;
      }

      public override bool OnGUI()
      {
         EditField("sendEvent");
         EditField("Mode");
         EditField("Text");
         EditField("RTVoiceNameWindows");
         EditField("RTVoiceNameMac");
         EditField("RTVoiceNameAndroid");
         EditField("RTVoiceNameIOS");
         EditField("RTVoiceNameWSA");
         EditField("RTVoiceNameMaryTTS");
         EditField("RTVoiceNameCustom");
         EditField("Culture");

         if (action.Mode == Model.Enum.SpeakMode.Speak)
         {
            GUILayout.BeginHorizontal();
            EditField("AudioSource");
            if (GUILayout.Button("Find in scene"))
            {
               action.AudioSource = GameObject.FindObjectOfType<AudioSource>().gameObject;
            }

            GUILayout.EndHorizontal();
         }

         EditField("Rate");
         EditField("Pitch");
         EditField("Volume");

         if (!EditorUtil.EditorHelper.isRTVoiceInScene)
         {
            EditorUtil.EditorHelper.NoVoicesUI();
         }

         /*
         EditorExt.EditorHelper.SeparatorUI();

         if (target.Enabled)
         {
             if (Speaker.isTTSAvailable)
             {
                 GUILayout.Label("Test-Drive", EditorStyles.boldLabel);

                 if (Util.Helper.isEditorMode)
                 {
                     if (GUILayout.Button("Speak"))
                     {
                         Model.Voice rtVoice = Speaker.VoiceForName(Util.Helper.isWindowsPlatform ? action.RTVoiceNameWindows.Value : action.RTVoiceNameMac.Value);

                         Speaker.SpeakNativeInEditor(action.Text.Value, rtVoice, action.Rate.Value, action.Pitch.Value, action.Volume.Value);
                     }

                     if (GUILayout.Button("Silence"))
                     {
                         Speaker.Silence();
                     }

                 }
                 else
                 {
                     GUILayout.Label("Disabled in Play-mode!");
                 }
             }
             else
             {
                 EditorExt.EditorHelper.NoVoicesUI();
             }
         }
         else
         {
             GUILayout.Label("Script is disabled!", EditorStyles.boldLabel);
         }
         */

         return GUI.changed;
      }
   }
}
#endif
// © 2016-2020 crosstales LLC (https://www.crosstales.com)