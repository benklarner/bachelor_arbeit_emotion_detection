#if PLAYMAKER
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
   /// <summary>Base for Speak-actions in PlayMaker.</summary>
   //[ActionCategory("Crosstales.RTVoice")]
   public abstract class SpeakBase : BaseRTVAction
   {
      #region Variables

      /// <summary>Speak mode (default: 'Speak').</summary>
      [Tooltip("Speak mode (default: 'Speak').")] public Crosstales.RTVoice.Model.Enum.SpeakMode Mode;


      /// <summary>AudioSource for the output (optional).</summary>
      [Header("Optional Settings")] [Tooltip("AudioSource for the output (optional).")] public FsmGameObject AudioSource;

      /// <summary>Speech rate of the speaker in percent (1 = 100%, default: 1, optional).</summary>
      [Tooltip("Speech rate of the speaker in percent (1 = 100%, default: 1, optional).")] [HasFloatSlider(0f, 3f)]
      public FsmFloat Rate = 1;

      /// <summary>Speech pitch of the speaker in percent (1 = 100%, default: 1, optional, mobile only).</summary>
      [Tooltip("Speech pitch of the speaker in percent (1 = 100%, default: 1, optional, mobile only).")] [HasFloatSlider(0f, 2f)]
      public FsmFloat Pitch = 1f;

      /// <summary>Volume of the speaker in percent (1 = 100%, default: 1, optional).</summary>
      [Tooltip("Volume of the speaker in percent (1 = 100%, default: 1, optional).")] [HasFloatSlider(0f, 1f)]
      public FsmFloat Volume = 1;

      protected string uid;

      #endregion


      #region Overridden methods

      public override void OnEnter()
      {
         subscribeEvents();
      }

      public override void OnExit()
      {
         //Debug.Log("OnExit");
         unsubscribeEvents();
      }

      #endregion


      #region Protected methods

      protected void subscribeEvents()
      {
         // Subscribe event listeners
         Crosstales.RTVoice.Speaker.OnSpeakComplete += speakCompleteMethod;
         //Crosstales.RTVoice.Speaker.OnSpeakAudioGenerationComplete += speakCompleteMethod;
      }

      protected void unsubscribeEvents()
      {
         // Unsubscribe event listeners
         Crosstales.RTVoice.Speaker.OnSpeakComplete -= speakCompleteMethod;
         //Crosstales.RTVoice.Speaker.OnSpeakAudioGenerationComplete -= speakCompleteMethod;
      }

      #endregion


      #region Callback methods

      private void speakCompleteMethod(Crosstales.RTVoice.Model.Wrapper wrapper)
      {
         //Debug.Log("speakCompleteMethod");

         if (uid.Equals(wrapper.Uid))
         {
            Fsm.Event(sendEvent);

            Finish();
         }
      }

      #endregion
   }
}
#endif
// © 2016-2020 crosstales LLC (https://www.crosstales.com)