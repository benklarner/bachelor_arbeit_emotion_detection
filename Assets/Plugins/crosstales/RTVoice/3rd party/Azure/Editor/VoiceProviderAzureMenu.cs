#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Crosstales.RTVoice.Azure
{
   /// <summary>Editor component for for adding the prefabs from 'Azure' in the "Tools"-menu.</summary>
   public static class VoiceProviderAWSMenu
   {
      [MenuItem("Tools/" + Util.Constants.ASSET_NAME + "/Prefabs/3rd party/Azure/VoiceProviderAzure", false, EditorUtil.EditorHelper.MENU_ID + 240)]
      private static void AddVoiceProvider()
      {
         PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets" + EditorUtil.EditorConfig.ASSET_PATH + "3rd party/Azure/Prefabs/Azure.prefab", typeof(GameObject)));
      }

      [MenuItem("Tools/" + Util.Constants.ASSET_NAME + "/Prefabs/3rd party/Azure/VoiceProviderAzure", true)]
      private static bool AddVoiceProviderValidator()
      {
         return !VoiceProviderAzureEditor.isPrefabInScene;
      }
   }
}
#endif
// © 2019-2020 crosstales LLC (https://www.crosstales.com)