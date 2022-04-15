using UnityEngine;

namespace Crosstales.RTVoice.Demo.Util
{
   /// <summary>Class for demo builds.</summary>
   [HelpURL("https://www.crosstales.com/media/data/assets/rtvoice/api/class_crosstales_1_1_r_t_voice_1_1_demo_1_1_util_1_1_custom_provider_controller.html")]
   public class CustomProviderController : MonoBehaviour
   {
      public Crosstales.RTVoice.Provider.BaseCustomVoiceProvider Provider;

#if CT_DEVELOP
      public void OnEnable()
      {
         Speaker.CustomVoiceProvider = Provider;
         Speaker.isCustomMode = true;
      }

      public void OnDisable()
      {
         Speaker.isCustomMode = false;
         Speaker.CustomVoiceProvider = null;
      }
#endif
   }
}
// © 2020 crosstales LLC (https://www.crosstales.com)