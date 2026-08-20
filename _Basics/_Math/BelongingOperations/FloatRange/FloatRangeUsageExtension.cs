namespace DenZ.DevelopmentTools.Math
{
    public static class FloatRangeUsageExtension
    {
        public static bool IsInside(this float value, FloatRange range, InclusionType1D inclusionType = InclusionType1D.BothSides) => range.ContainsValue(value, inclusionType);
        public static bool IsInside(this float value, (float, float) range, InclusionType1D inclusionType = InclusionType1D.BothSides) => IsInside(value, (FloatRange)range, inclusionType);
        public static bool IsInside(this float value, float a, float b, InclusionType1D inclusionType = InclusionType1D.BothSides) => IsInside(value, new FloatRange(a, b), inclusionType);
        public static bool ContainsValue(this (float, float) range, float value, InclusionType1D inclusionType = InclusionType1D.BothSides) => IsInside(value, (FloatRange)range, inclusionType);
    }
}