#if PLAYMAKER
using System.Collections;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
   /// <summary>GetVoices-action for PlayMaker.</summary>
   [ActionCategory("Crosstales.RTVoice")]
   [HelpUrl("https://www.crosstales.com/media/data/assets/rtvoice/api/class_hutong_games_1_1_play_maker_1_1_actions_1_1_get_voices.html")]
   public class GetVoices : BaseRTVAction
   {
      #region Variables

      /// <summary>Culture of the voices (e.g. 'en', blank for all cultures).</summary>
      [Tooltip("Culture of the voices (e.g. 'en', blank for all cultures).")] public FsmString Culture;

      /// <summary>Gender of the voices ('m' or 'male' for males, 'f' or 'female' for females, blank for all genders).</summary>
      [Tooltip("Gender of the voices ('m' or 'male' for males, 'f' or 'female' for females, blank for all genders).")]
      public FsmString Gender;

      /// <summary>Found voices (output array).</summary>
      [Tooltip("Found voices (output array).")] [ArrayEditor(VariableType.String)] public FsmArray Voices;

      #endregion


      #region Overridden methods

      public override void OnEnter()
      {
         StartCoroutine(readVoices());
      }

      #endregion


      #region Private methods

      private IEnumerator readVoices()
      {
         while (!Crosstales.RTVoice.Speaker.areVoicesReady)
         {
            yield return null;
         }

         if (string.IsNullOrEmpty(Culture.Value) && string.IsNullOrEmpty(Gender.Value))
         {
            //Voices = new FsmArray();

            string[] voices = new string[Crosstales.RTVoice.Speaker.Voices.Count];

            for (int ii = 0; ii < Crosstales.RTVoice.Speaker.Voices.Count; ii++)
            {
               voices[ii] = Crosstales.RTVoice.Speaker.Voices[ii].Name;
            }

            //Debug.Log(voices.Length);

            Voices.Values = voices;
         }
         else
         {
            Crosstales.RTVoice.Model.Voice[] voices = Crosstales.RTVoice.Speaker.VoicesForGender(Crosstales.RTVoice.Util.Helper.StringToGender(Gender.Value), Culture.Value).ToArray();

            //Voices = new FsmArray();

            string[] voiceArray = new string[voices.Length];

            for (int ii = 0; ii < voices.Length; ii++)
            {
               voiceArray[ii] = voices[ii].Name;
            }

            Voices.Values = voiceArray;
         }

         Fsm.Event(sendEvent);

         Finish();
      }

      #endregion
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)