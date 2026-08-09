using UnityEngine;

namespace DenZ.DevelopmentTools.Math
{
    public struct SphereVector
    {
        public float R; // [0, ∞)
        public float Phi; // [0, 2π)
        public float Theta; // [0, π]

        public SphereVector(float r, float phi, float theta)
        {
            R = r;
            Phi = phi;
            Theta = theta;
        }

        public readonly void Deconstruct(out float r, out float phi, out float theta)
        {
            r = R;
            phi = Phi;
            theta = Theta;
        }

        public readonly Vector3 ToCartesian()
        {
            var x = R * Mathf.Sin(Theta) * Mathf.Cos(Phi);
            var y = R * Mathf.Cos(Theta);
            var z = R * Mathf.Sin(Theta) * Mathf.Sin(Phi);
            return new(x, y, z);
        }
    }
}