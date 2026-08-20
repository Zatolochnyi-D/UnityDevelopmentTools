namespace DenZ.DevelopmentTools.Math
{
    public static class IntRangeUsageExtension
    {
        public static bool IsInside(this int value, IntRange range, InclusionType1D inclusionType = InclusionType1D.LeftSide) => range.ContainsValue(value, inclusionType);
        public static bool IsInside(this int value, (int, int) range, InclusionType1D inclusionType = InclusionType1D.LeftSide) => IsInside(value, (IntRange)range, inclusionType);
        public static bool IsInside(this int value, int a, int b, InclusionType1D inclusionType = InclusionType1D.LeftSide) => IsInside(value, new IntRange(a, b), inclusionType);
        public static bool ContainsValue(this (int, int) range, int value, InclusionType1D inclusionType = InclusionType1D.LeftSide) => IsInside(value, (IntRange)range, inclusionType);
    }
}