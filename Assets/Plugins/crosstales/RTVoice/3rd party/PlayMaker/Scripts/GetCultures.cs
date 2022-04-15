#if PLAYMAKER
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
   /// <summary>GetCultures-action for PlayMaker.</summary>
   [ActionCategory("Crosstales.RTVoice")]
   [HelpUrl("https://www.crosstales.com/media/data/assets/rtvoice/api/class_hutong_games_1_1_play_maker_1_1_actions_1_1_get_cultures.html")]
   public class GetCultures : BaseRTVAction
   {
      #region Variables

      /// <summary>Found cultures (output array).</summary>
      [Tooltip("Found cultures (output array).")] [ArrayEditor(VariableType.String)] public FsmArray Cultures;

      #endregion


      #region Overridden methods

      public override void OnEnter()
      {
         StartCoroutine(readCultures());
      }

      #endregion


      #region Private methods

      private IEnumerator readCultures()
      {
         while (!Crosstales.RTVoice.Speaker.areVoicesReady)
         {
            yield return null;
         }

         Cultures.Values = Crosstales.RTVoice.Speaker.Cultures.ToArray();

         Fsm.Event(sendEvent);

         Finish();
      }

      #endregion
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)