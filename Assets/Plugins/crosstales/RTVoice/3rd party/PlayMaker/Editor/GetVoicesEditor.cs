#if PLAYMAKER && UNITY_EDITOR
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

namespace Crosstales.RTVoice.PlayMaker
{
   /// <summary>Custom editor for the GetVoices-action.</summary>
   [CustomActionEditor(typeof(GetVoices))]
   public class GetVoicesEditor : BaseRTVEditor
   {
      //empty
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)