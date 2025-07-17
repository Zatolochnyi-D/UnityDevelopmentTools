using UnityEngine;

namespace ThreeDent.DevelopmentTools.Utilities
{
    public static class AudioUtils
    {
        /// <summary>
        /// Converts linear normalized volume into audio mixer's attenuation value.
        /// </summary>
        /// <param name="volume">Volume value in range (0.0, 1.0]. Value is clamped to this range.</param>
        /// <returns>Corresponding attenuation value.</returns>
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