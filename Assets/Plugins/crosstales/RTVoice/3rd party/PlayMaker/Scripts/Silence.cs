#if PLAYMAKER
namespace HutongGames.PlayMaker.Actions
{
   /// <summary>Silence-action for PlayMaker.</summary>
   [ActionCategory("Crosstales.RTVoice")]
   [HelpUrl("https://www.crosstales.com/media/data/assets/rtvoice/api/class_hutong_games_1_1_play_maker_1_1_actions_1_1_silence.html")]
   public class Silence : BaseRTVAction
   {
      #region Overridden methods

      public override void OnEnter()
      {
         Crosstales.RTVoice.Speaker.Silence();

         Fsm.Event(sendEvent);

         Finish();
      }

      #endregion
   }
}
#endif
// © 2016-2020 crosstales LLC (https://www.crosstales.com)