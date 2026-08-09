using UnityEngine;

namespace DenZ.DevelopmentTools.Math
{
    public struct SphereVector
    {
        public static SphereVector FromDegrees(float r, float degreePhi, float degreeTheta)
        {
            return new(r, degreePhi * Mathf.Deg2Rad, degreeTheta * Mathf.Deg2Rad);
        }

        public float R; // [0, ∞)
        public float Phi; // [0, 2π)
        public float Theta; // [0, π]

        public SphereVector(float r, float radianPhi, float radianTheta)
        {
            R = r;
            Phi = radianPhi;
            Theta = radianTheta;
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