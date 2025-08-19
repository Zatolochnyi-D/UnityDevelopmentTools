using UnityEngine;

namespace ThreeDent.DevelopmentTools.SceneReference
{
    /// <summary>
    /// Serializable scene reference, that allows to save scene names for using in build version.
    /// </summary>
    [System.Serializable]
    public class SceneReference
    {
        [SerializeField] private Object sceneAsset; // Reference to assigned scene or null if nothing is assigned
        [SerializeField] private string sceneName; // Name of current or previous assigned scene (if that scene ))

        public string SceneName => sceneName;
        public Object SceneAsset => sceneAsset;
        public bool IsEmpty => sceneAsset == null;
    }
}