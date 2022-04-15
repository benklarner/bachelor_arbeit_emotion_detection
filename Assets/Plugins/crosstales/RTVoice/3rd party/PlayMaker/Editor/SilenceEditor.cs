#if PLAYMAKER && UNITY_EDITOR
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

namespace Crosstales.RTVoice.PlayMaker
{
   /// <summary>Custom editor for the Silence-action.</summary>
   [CustomActionEditor(typeof(Silence))]
   public class SilenceEditor : BaseRTVEditor
   {
      //empty
   }
}
#endif
// © 2017-2020 crosstales LLC (https://www.crosstales.com)