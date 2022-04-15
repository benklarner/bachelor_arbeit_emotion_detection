#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Crosstales.RTVoice.SAPI
{
   /// <summary>Editor component for for adding the prefabs from 'SAPI Unity' in the "Hierarchy"-menu.</summary>
   public static class VoiceProviderSAPIGameObject
   {
      [MenuItem("GameObject/" + Util.Constants.ASSET_NAME + "/3rd party/SAPI Unity/VoiceProviderSAPI", false, EditorUtil.EditorHelper.GO_ID + 20)]
      private static void AddVoiceProvider()
      {
         PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets" + EditorUtil.EditorConfig.ASSET_PATH + "3rd party/SAPI Unity/Prefabs/SAPI Unity.prefab", typeof(GameObject)));
      }

      [MenuItem("GameObject/" + Util.Constants.ASSET_NAME + "/3rd party/SAPI Unity/VoiceProviderSAPI", true)]
      private static bool AddVoiceProviderValidator()
      {
         return !VoiceProviderSAPIEditor.isPrefabInScene;
      }
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)