#if PLAYMAKER
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
   /// <summary>Speak-action for UI-components in PlayMaker.</summary>
   [ActionCategory("Crosstales.RTVoice")]
   [HelpUrl("https://www.crosstales.com/media/data/assets/rtvoice/api/class_hutong_games_1_1_play_maker_1_1_actions_1_1_speak_u_i.html")]
   public class SpeakUI : SpeakBase
   {
      #region Variables

      /// <summary>Text to speak.</summary>
      [Tooltip("Text to speak.")] [RequiredField] public InputField Text;

      /// <summary>Name of the RT-Voice.</summary>
      [Tooltip("Name of the RT-Voice.")] public InputField RTVoiceName;

      /// <summary>Fallback culture (e.g. 'en', optional).</summary>
      [Tooltip("Fallback culture (e.g. 'en', optional).")] public FsmString Culture = "en";

      #endregion


      #region Overridden methods

      public override void OnEnter()
      {
         base.OnEnter();

         if (string.IsNullOrEmpty(Text.text))
         {
            Text.text = "This demo scene shows a 'Speak UI'-action. Please type something here...";
         }

         Crosstales.RTVoice.Model.Voice rtVoice = null;

         if (RTVoiceName != null)
         {
            if (string.IsNullOrEmpty(RTVoiceName.text))
            {
               RTVoiceName.text = Crosstales.RTVoice.Util.Helper.isWindowsPlatform ? "Microsoft David Desktop" : "Alex";
            }

            rtVoice = Crosstales.RTVoice.Speaker.VoiceForName(RTVoiceName.text);
         }

         if (rtVoice == null)
         {
            rtVoice = Crosstales.RTVoice.Speaker.VoiceForCulture(Culture.Value);
         }

         if (Mode == Crosstales.RTVoice.Model.Enum.SpeakMode.Speak)
         {
            AudioSource src = null;

            if (AudioSource.Value != null)
            {
               src = AudioSource.Value.GetComponent<AudioSource>();
            }

            uid = Crosstales.RTVoice.Speaker.Speak(Text.text, src, rtVoice, true, Rate.Value, Pitch.Value, Volume.Value);
         }
         else
         {
            uid = Crosstales.RTVoice.Speaker.SpeakNative(Text.text, rtVoice, Rate.Value, Pitch.Value, Volume.Value);
         }
      }

      #endregion
   }
}
#endif
// © 2016-2020 crosstales LLC (https://www.crosstales.com)