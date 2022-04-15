#if PLAYMAKER && UNITY_EDITOR
using UnityEngine;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

namespace Crosstales.RTVoice.PlayMaker
{
   /// <summary>Custom editor for the SpeakUI-action.</summary>
   [CustomActionEditor(typeof(SpeakUI))]
   public class SpeakUIEditor : CustomActionEditor
   {
      private SpeakUI action;

      public override void OnEnable()
      {
         action = target as SpeakUI;
      }

      public override bool OnGUI()
      {
         //var action = target as SpeakUI;

         EditField("sendEvent");
         EditField("Mode");
         EditField("Text");
         EditField("RTVoiceName");
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
         if (!Speaker.isTTSAvailable)
         {
             EditorExt.EditorHelper.SeparatorUI();

             EditorExt.EditorHelper.NoVoicesUI();
         }
         */

         return GUI.changed;
      }
   }
}
#endif
// © 2016-2020 crosstales LLC (https://www.crosstales.com)