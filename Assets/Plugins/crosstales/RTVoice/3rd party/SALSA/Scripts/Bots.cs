using UnityEngine;

namespace Crosstales.RTVoice.SALSA
{
   /// <summary>This is a class for conversations between two SALSA-Bots.</summary>
   [HelpURL("https://www.crosstales.com/media/data/assets/rtvoice/api/class_crosstales_1_1_r_t_voice_1_1_s_a_l_s_a_1_1_bots.html")]
   public class Bots : MonoBehaviour
   {
      #region Variables

      [Tooltip("Origin AudioSource from BotA.")] public AudioSource SourceA;

      [Tooltip("Origin AudioSource from BotB.")] public AudioSource SourceB;

      [Tooltip("All conversations from BotA.")] public string[] ConverstationsA;

      [Tooltip("All conversations from BotB.")] public string[] ConverstationsB;

      private bool talking = false;
      private int converstaionAIndex = -1;
      private int converstaionBIndex = -1;
      private string id = string.Empty;

      private bool isBotBSpeaking = true;

      #endregion


      #region MonoBehaviour methods

      public void OnEnable()
      {
         // Subscribe event listeners
         Speaker.OnSpeakComplete += speakCompleteMethod;
      }

      public void OnDisable()
      {
         // Unsubscribe event listeners
         Speaker.OnSpeakComplete -= speakCompleteMethod;
      }

      public void Update()
      {
         //if (!talking && !Salsa.isTalking && !SalsaPartner.isTalking)
         if (!talking && !Util.Helper.hasActiveClip(SourceA) && !Util.Helper.hasActiveClip(SourceB))
         {
            talking = true;

            if (isBotBSpeaking)
            {
               if (converstaionAIndex + 1 < ConverstationsA.Length)
               {
                  converstaionAIndex++;

                  id = Speaker.Speak(ConverstationsA[converstaionAIndex], SourceA, Speaker.VoiceForCulture("en"), true); //speak next conversation
               }
               else
               {
                  Debug.Log("BotA finished talking", this);
               }

               isBotBSpeaking = false;
            }
            else
            {
               if (converstaionBIndex + 1 < ConverstationsB.Length)
               {
                  converstaionBIndex++;

                  id = Speaker.Speak(ConverstationsB[converstaionBIndex], SourceB, Speaker.VoiceForCulture("en"), true); //speak next partner conversation
               }
               else
               {
                  Debug.Log("BotB finished talking", this);
               }

               isBotBSpeaking = true;
            }
         }
      }

      #endregion


      #region Private methods

      private void speakCompleteMethod(Model.Wrapper wrapper)
      {
         if (id.Equals(wrapper.Uid)) //is it our Speak-call?
         {
            Debug.Log("Generated audio: " + wrapper, this); //contains also the text and much more

            talking = false;
         }
      }

      #endregion
   }
}
// © 2017-2020 crosstales LLC (https://www.crosstales.com)