#if PLAYMAKER && UNITY_EDITOR
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

namespace Crosstales.RTVoice.PlayMaker
{
   /// <summary>Custom editor for the TextFileSpeaker-action.</summary>
   [CustomActionEditor(typeof(TextFileSpeaker))]
   public class TextFileSpeakerEditor : BaseRTVEditor
   {
      //empty
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)