namespace Crosstales.RTVoice.Util
{
   /// <summary>Context for the asset.</summary>
   public static class Context
   {
      #region Changable variables

      /// <summary>The current total number of speaks.</summary>
      public static int NumberOfSpeaks = 0;

      /// <summary>The current total number of generated audio files.</summary>
      public static int NumberOfAudioFiles = 0;

      /// <summary>The current total number of characters to speech.</summary>
      public static int NumberOfCharacters = 0;

      /// <summary>The current total speech length in seconds.</summary>
      public static float TotalSpeechLength = 0;
      
      #endregion

   }
}
// © 2020 crosstales LLC (https://www.crosstales.com)