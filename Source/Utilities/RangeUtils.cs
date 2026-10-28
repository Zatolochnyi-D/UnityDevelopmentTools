using System;
using DenZ.DevelopmentTools.Extensions;
using UnityEngine;

namespace DenZ.DevelopmentTools.Utilities
{
    [Flags]
    public enum Inclusion1D
    {
        None = 0b_00,
        Left = 0b_01,
        Right = 0b_10,
    }

    [Flags]
    public enum Inclusion2D
    {
        None = 0b_0000,
        Top = 0b_0001,
        Right = 0b_0010,
        Bottom = 0b_0100,
        Left = 0b_1000,
    }

    public static class RangeUtils
    {
        public static bool IsInside(int value, int min, int max, Inclusion1D inclusion = Inclusion1D.Left)
        {
            (min, max) = (Mathf.Min(min, max), Mathf.Max(min, max)); // Ensure min is less than max. Allows to provide min > max.

            return inclusion switch
            {
                Inclusion1D.None => value > min && value < max,
                Inclusion1D.Left => value >= min && value < max,
                Inclusion1D.Right => value > min && value <= max,
                Inclusion1D.Left | Inclusion1D.Right => value >= min && value <= max,
                _ => throw FastExeptions.NonExistentEnumValue<Inclusion1D>(),
            };
        }

        public static bool IsInside(Vector2Int point, Vector2Int lowerPoint, Vector2Int upperPoint, Inclusion2D inclusion = Inclusion2D.Left | Inclusion2D.Bottom)
        {
            var (x, y) = point;
            var (ax, ay) = lowerPoint;
            var (bx, by) = upperPoint;

            (ax, ay) = (Mathf.Min(ax, bx), Mathf.Min(ay, by));
            (bx, by) = (Mathf.Max(ax, bx), Mathf.Max(ay, by));

            var inclusionX = inclusion switch
            {
                var i when (i & (Inclusion2D.Left | Inclusion2D.Right)) == (Inclusion2D.Left | Inclusion2D.Right) => Inclusion1D.Left | Inclusion1D.Right,
                var i when (i & Inclusion2D.Left) != 0 => Inclusion1D.Left,
                var i when (i & Inclusion2D.Right) != 0 => Inclusion1D.Right,
                _ => Inclusion1D.None,
            };
            var inclusionY = inclusion switch
            {
                var i when (i & (Inclusion2D.Bottom | Inclusion2D.Top)) == (Inclusion2D.Bottom | Inclusion2D.Top) => Inclusion1D.Left | Inclusion1D.Right,
                var i when (i & Inclusion2D.Bottom) != 0 => Inclusion1D.Left,
                var i when (i & Inclusion2D.Top) != 0 => Inclusion1D.Right,
                _ => Inclusion1D.None,
            };

            return IsInside(x, ax, bx, inclusionX) && IsInside(y, ay, by, inclusionY);
        }
    }
}