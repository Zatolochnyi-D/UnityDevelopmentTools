using System.Runtime.CompilerServices;
using DenZ.DevelopmentTools.Extensions;
using DenZ.DevelopmentTools.Options;
using UnityEngine;

namespace DenZ.DevelopmentTools.Math
{
    public struct SphereVector
    {
        public static SphereVector FromDegrees(float r, float degreePhi, float degreeTheta)
        {
            return new(r, degreePhi * Mathf.Deg2Rad, degreeTheta * Mathf.Deg2Rad);
        }

        public static SphereVector FromVector(Vector3 vector)
        {
            var r = Mathf.Sqrt(Mathf.Pow(vector.x, 2f) + Mathf.Pow(vector.y, 2f) + Mathf.Pow(vector.z, 2f));

            float phi = vector switch
            {
                var (x, _, z) when x > 0f => Mathf.Atan(z / x),
                var (x, _, z) when x < 0f && z >= 0f => Mathf.Atan(z / x) + Mathf.PI,
                var (x, _, z) when x < 0f && z < 0f => Mathf.Atan(z / x) - Mathf.PI,
                var (x, _, z) when x == 0f && z > 0f => Mathf.PI / 2f,
                var (x, _, z) when x == 0f && z < 0f => -Mathf.PI / 2f,
                (_, _, _) => 0f
            };

            float theta = vector switch
            {
                var (x, y, z) when y > 0f => Mathf.Atan(Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(z, 2f)) / y),
                var (x, y, z) when y < 0f => Mathf.PI + Mathf.Atan(Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(z, 2f)) / y),
                var (x, y, z) when y == 0f && r != 0f => Mathf.PI / 2f,
                (_, _, _) => 0f
            };

            return new(r, phi, theta);
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

        public override readonly string ToString()
        {
            return $"({R}, {Phi} ({Phi * Mathf.Rad2Deg}°), {Theta} ({Theta * Mathf.Rad2Deg}°))";
        }
    }

    public static class Vector3ConvertionExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SphereVector ToSpherical(this Vector3 vector)
        {
            return SphereVector.FromVector(vector);
        }
    }

    // TODO: find a proper place for extensions of custom classes (like those).
    public static class SphereVectorExtension
    {
        public static SphereVector With(this SphereVector vector, Option<float> r = default, Option<float> phi = default, Option<float> theta = default)
        {
            return new SphereVector(
                r.ReadOrDefault(vector.R),
                phi.ReadOrDefault(vector.Phi),
                theta.ReadOrDefault(vector.Theta)
            );
        }
    }
}