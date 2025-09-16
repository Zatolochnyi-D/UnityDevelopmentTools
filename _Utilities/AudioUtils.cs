using UnityEngine;

namespace ThreeDent.DevelopmentTools.Utilities
{
    public static class AudioUtils
    {
        public static float NormalizedVolumeToAttenuation(float volume)
        {
            float minVolume = 0.0001f;
            float maxVolume = 1f;
            float resultMultiplier = 20f;

            volume = Mathf.Clamp(volume, minVolume, maxVolume);
            return Mathf.Log10(volume) * resultMultiplier;
        }
    }
}