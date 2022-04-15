#if PLAYMAKER && UNITY_EDITOR
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

namespace Crosstales.RTVoice.PlayMaker
{
   /// <summary>Custom editor for the AudioFileGenerator-action.</summary>
   [CustomActionEditor(typeof(AudioFileGenerator))]
   public class AudioFileGeneratorEditor : BaseRTVEditor
   {
      //empty
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)