#if PLAYMAKER && UNITY_EDITOR
using UnityEngine;
using HutongGames.PlayMakerEditor;

namespace Crosstales.RTVoice.PlayMaker
{
   /// <summary>Base class for RT-Voice custom editors in PlayMaker.</summary>
   public abstract class BaseRTVEditor : CustomActionEditor
   {
      public override bool OnGUI()
      {
         bool isDirty = DrawDefaultInspector();

         if (!EditorUtil.EditorHelper.isRTVoiceInScene)
         {
            EditorUtil.EditorHelper.NoVoicesUI();
         }

         return isDirty || GUI.changed;
      }
   }
}
#endif
// © 2017-2020 crosstales LLC (https://www.crosstales.com)