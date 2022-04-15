#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Crosstales.RTVoice.Azure
{
   /// <summary>Editor component for for adding the prefabs from 'Azure' in the "Hierarchy"-menu.</summary>
   public static class VoiceProviderAzureGameObject
   {
      [MenuItem("GameObject/" + Util.Constants.ASSET_NAME + "/3rd party/Azure/VoiceProviderAzure", false, EditorUtil.EditorHelper.GO_ID + 20)]
      private static void AddVoiceProvider()
      {
         PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets" + EditorUtil.EditorConfig.ASSET_PATH + "3rd party/Azure/Prefabs/Azure.prefab", typeof(GameObject)));
      }

      [MenuItem("GameObject/" + Util.Constants.ASSET_NAME + "/3rd party/Azure/VoiceProviderAzure", true)]
      private static bool AddVoiceProviderValidator()
      {
         return !VoiceProviderAzureEditor.isPrefabInScene;
      }
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)