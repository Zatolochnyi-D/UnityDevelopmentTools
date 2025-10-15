using UnityEngine;

namespace DenZ.DevelopmentTools.SceneReference
{
    [System.Serializable]
    public class SceneReference
    {
        [SerializeField] private Object sceneAsset; // Reference to assigned scene or null if nothing is assigned
        [SerializeField] private string sceneName; // Name of current assigned scene or null if nothing is assigned

        public string SceneName => sceneName;
        public Object SceneAsset => sceneAsset;
        public bool IsEmpty => sceneAsset == null;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj is SceneReference reference)
                return sceneAsset.Equals(reference.sceneAsset);
            return false;
        }

        public override int GetHashCode()
        {
            return sceneAsset.GetHashCode();
        }

        public static bool operator ==(SceneReference a, SceneReference b)
        {
            return Equals(a, b);
            // return a.Equals(b);
        }

        public static bool operator !=(SceneReference a, SceneReference b)
        {
            return !(a == b);
        }
    }
}