#if PLAYMAKER
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
   /// <summary>AudioFileGenerator-action for PlayMaker.</summary>
   [ActionCategory("Crosstales.RTVoice")]
   [HelpUrl("https://www.crosstales.com/media/data/assets/rtvoice/api/class_hutong_games_1_1_play_maker_1_1_actions_1_1_audio_file_generator.html")]
   public class AudioFileGenerator : BaseRTVAction
   {
      /// <summary>Add a AudioFileGenerator (default: first object in scene).</summary>
      [Tooltip("Add a AudioFileGenerator (default: first object in scene).")] [RequiredField] public Crosstales.RTVoice.Tool.AudioFileGenerator Obj;

      #region Overridden methods

      public override void OnEnter()
      {
         if (Obj == null)
         {
            Obj = GameObject.Find("AudioFileGenerator").GetComponent<Crosstales.RTVoice.Tool.AudioFileGenerator>();
         }

         if (Obj != null)
         {
            Obj.OnAudioFileGeneratorComplete += completeMethod;

            Obj.Generate();
         }
         else
         {
            Debug.LogWarning("'AudioFileGenerator' not found! Please add an object from the scene.");

            Fsm.Event(sendEvent);

            Finish();
         }
      }

      public override void OnExit()
      {
         if (Obj != null)
         {
            Obj.OnAudioFileGeneratorComplete -= completeMethod;
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