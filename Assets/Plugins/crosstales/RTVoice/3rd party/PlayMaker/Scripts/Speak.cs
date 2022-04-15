#if PLAYMAKER
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
   /// <summary>Speak-action for PlayMaker.</summary>
   [ActionCategory("Crosstales.RTVoice")]
   [HelpUrl("https://www.crosstales.com/media/data/assets/rtvoice/api/class_hutong_games_1_1_play_maker_1_1_actions_1_1_speak.html")]
   public class Speak : SpeakBase
   {
      #region Variables

      /// <summary>Text to speak.</summary>
      [Tooltip("Text to speak.")] [RequiredField] public FsmString Text = "Hello world!";

      /// <summary>Name of the RT-Voice under Windows.</summary>
      [Tooltip("Name of the RT-Voice under Windows.")] public FsmString RTVoiceNameWindows = "David";

      /// <summary>Name of the RT-Voice under macOS.</summary>
      [Tooltip("Name of the RT-Voice under macOS.")] public FsmString RTVoiceNameMac = "Alex";

      /// <summary>Name of the RT-Voice under Android.</summary>
      [Tooltip("Name of the RT-Voice under Android.")] public FsmString RTVoiceNameAndroid = "en";

      /// <summary>Name of the RT-Voice under iOS.</summary>
      [Tooltip("Name of the RT-Voice under iOS.")] public FsmString RTVoiceNameIOS = "Daniel";

      /// <summary>Name of the RT-Voice under WSA.</summary>
      [Tooltip("Name of the RT-Voice under WSA.")] public FsmString RTVoiceNameWSA = "David";

      /// <summary>Name of the RT-Voice under MaryTTS.</summary>
      [Tooltip("Name of the RT-Voice under MaryTTS.")] public FsmString RTVoiceNameMaryTTS = "cms-rms-hsmm";

      /// <summary>Name of the RT-Voice in a custom provider.</summary>
      [Tooltip("Name of the RT-Voice in a custom provider.")] public FsmString RTVoiceNameCustom = string.Empty;

      /// <summary>Fallback culture (e.g. 'en', optional).</summary>
      [Tooltip("Fallback culture (e.g. 'en', optional).")] public FsmString Culture = "en";

      #endregion


      #region Overridden methods

      public override void OnEnter()
      {
         base.OnEnter();

         Crosstales.RTVoice.Model.Voice rtVoice = voice ?? Crosstales.RTVoice.Speaker.VoiceForCulture(Culture.Value);

         if (Mode == Crosstales.RTVoice.Model.Enum.SpeakMode.Speak)
         {
            AudioSource src = null;

            if (AudioSource.Value != null)
            {
               src = AudioSource.Value.GetComponent<AudioSource>();
            }

            uid = Crosstales.RTVoice.Speaker.Speak(Text.Value, src, rtVoice, true, Rate.Value, Pitch.Value, Volume.Value);
         }
         else
         {
            uid = Crosstales.RTVoice.Speaker.SpeakNative(Text.Value, rtVoice, Rate.Value, Pitch.Value, Volume.Value);
         }
      }

      #endregion


      #region Private methods

      private Crosstales.RTVoice.Model.Voice voice
      {
         get
         {
            Crosstales.RTVoice.Model.Voice result = null;

            if (Crosstales.RTVoice.Speaker.CustomVoiceProvider == null)
            {
               if (Crosstales.RTVoice.Speaker.isMaryMode)
               {
                  result = Crosstales.RTVoice.Speaker.VoiceForName(RTVoiceNameMaryTTS.Value);
               }
               else
               {
                  if (Crosstales.RTVoice.Util.Helper.isWindowsPlatform)
                  {
                     result = Crosstales.RTVoice.Speaker.VoiceForName(RTVoiceNameWindows.Value);
                  }
                  else if (Crosstales.RTVoice.Util.Helper.isMacOSPlatform)
                  {
                     result = Crosstales.RTVoice.Speaker.VoiceForName(RTVoiceNameMac.Value);
                  }
                  else if (Crosstales.RTVoice.Util.Helper.isAndroidPlatform)
                  {
                     result = Crosstales.RTVoice.Speaker.VoiceForName(RTVoiceNameAndroid.Value);
                  }
                  else if (Crosstales.RTVoice.Util.Helper.isWSABasedPlatform)
                  {
                     result = Crosstales.RTVoice.Speaker.VoiceForName(RTVoiceNameWSA.Value);
                  }
                  else
                  {
                     result = Crosstales.RTVoice.Speaker.VoiceForName(RTVoiceNameIOS.Value);
                  }
               }
            }
            else
            {
               result = Crosstales.RTVoice.Speaker.VoiceForName(RTVoiceNameCustom.Value);
            }

            return result;
         }
      }

      #endregion
   }
}
#endif
// © 2016-2020 crosstales LLC (https://www.crosstales.com)