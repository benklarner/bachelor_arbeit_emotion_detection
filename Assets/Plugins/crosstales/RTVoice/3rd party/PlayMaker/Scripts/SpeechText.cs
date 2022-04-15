#if PLAYMAKER
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
   /// <summary>SpeechText-action for PlayMaker.</summary>
   [ActionCategory("Crosstales.RTVoice")]
   [HelpUrl("https://www.crosstales.com/media/data/assets/rtvoice/api/class_hutong_games_1_1_play_maker_1_1_actions_1_1_speech_text.html")]
   public class SpeechText : BaseRTVAction
   {
      /// <summary>Add a SpeechText (default: first object in scene).</summary>
      [Tooltip("Add a SpeechText (default: first object in scene).")] [RequiredField] public Crosstales.RTVoice.Tool.SpeechText Obj;

      #region Overridden methods

      public override void OnEnter()
      {
         if (Obj == null)
         {
            Obj = GameObject.Find("SpeechText").GetComponent<Crosstales.RTVoice.Tool.SpeechText>();
         }

         if (Obj != null)
         {
            Obj.OnSpeechTextComplete += completeMethod;

            Obj.Speak();
         }
         else
         {
            Debug.LogWarning("'SpeechText' not found! Please add an object from the scene.");

            Fsm.Event(sendEvent);

            Finish();
         }
      }

      public override void OnExit()
      {
         if (Obj != null)
         {
            Obj.OnSpeechTextComplete -= completeMethod;
         }
      }

      #endregion


      #region Callback methods

      private void completeMethod()
      {
         Fsm.Event(sendEvent);

         Finish();
      }

      #endregion
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)