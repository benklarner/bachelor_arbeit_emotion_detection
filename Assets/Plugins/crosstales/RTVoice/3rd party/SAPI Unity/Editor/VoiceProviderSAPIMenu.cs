#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Crosstales.RTVoice.SAPI
{
   /// <summary>Editor component for for adding the prefabs from 'SAPI Unity' in the "Tools"-menu.</summary>
   public static class VoiceProviderSAPIMenu
   {
      [MenuItem("Tools/" + Util.Constants.ASSET_NAME + "/Prefabs/3rd party/SAPI Unity/VoiceProviderSAPI", false, EditorUtil.EditorHelper.MENU_ID + 300)]
      private static void AddVoiceProvider()
      {
         PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets" + EditorUtil.EditorConfig.ASSET_PATH + "3rd party/SAPI Unity/Prefabs/SAPI Unity.prefab", typeof(GameObject)));
      }

      [MenuItem("Tools/" + Util.Constants.ASSET_NAME + "/Prefabs/3rd party/SAPI Unity/VoiceProviderSAPI", true)]
      private static bool AddVoiceProviderValidator()
      {
         return !VoiceProviderSAPIEditor.isPrefabInScene;
      }
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)