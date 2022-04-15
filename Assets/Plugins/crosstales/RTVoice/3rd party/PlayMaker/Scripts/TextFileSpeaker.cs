#if PLAYMAKER
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
   /// <summary>TextFileSpeaker-action for PlayMaker.</summary>
   [ActionCategory("Crosstales.RTVoice")]
   [HelpUrl("https://www.crosstales.com/media/data/assets/rtvoice/api/class_hutong_games_1_1_play_maker_1_1_actions_1_1_text_file_speaker.html")]
   public class TextFileSpeaker : BaseRTVAction
   {
      /// <summary>Add a TextFileSpeaker (default: first object in scene).</summary>
      [Tooltip("Add a TextFileSpeaker (default: first object in scene).")] [RequiredField] public Crosstales.RTVoice.Tool.TextFileSpeaker Obj;

      #region Overridden methods

      public override void OnEnter()
      {
         if (Obj == null)
         {
            Obj = GameObject.Find("TextFileSpeaker").GetComponent<Crosstales.RTVoice.Tool.TextFileSpeaker>();
         }

         if (Obj != null)
         {
            Obj.Speak();
         }
         else
         {
            Debug.LogWarning("'TextFileSpeaker' not found! Please add an object from the scene.");

            Fsm.Event(sendEvent);

            Finish();
         }
      }

      #endregion
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)