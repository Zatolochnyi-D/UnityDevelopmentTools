using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public enum InclusionType
    {
        NeitherSide = 0b_00,
        LeftSide = 0b_01,
        RightSide = 0b_10,
        BothSides = 0b_11,
    }

    public static class InOutsideExtensions
    {
        public static bool IsInsideRange(this int value, (int, int) range, InclusionType inclusionType = InclusionType.LeftSide)
        {
            return inclusionType switch
            {
                InclusionType.NeitherSide => value > range.Item1 && value < range.Item2,
                InclusionType.LeftSide => value >= range.Item1 && value < range.Item2,
                InclusionType.RightSide => value > range.Item1 && value <= range.Item2,
                InclusionType.BothSides => value >= range.Item1 && value <= range.Item2,
                _ => throw FastExeptions.NonExistentEnumValue<InclusionType>(),
            };
        }

        public static bool IsOutsideRange(this int value, (int, int) range, InclusionType inclusionType = InclusionType.LeftSide)
        {
            return !value.IsInsideRange(range, inclusionType);
        }
    }
}