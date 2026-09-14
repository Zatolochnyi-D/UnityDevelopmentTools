namespace DenZ.DevelopmentTools.Math
{
    public struct FloatRange
    {
        public static implicit operator FloatRange((float, float) tuple) => new (tuple);
        public static implicit operator (float, float)(FloatRange range) => (range.Start, range.End);

        public float Start;
        public float End;

        public FloatRange(float start, float end) => (Start, End) = (start, end);
        public FloatRange((float, float) tupleRange) => (Start, End) = tupleRange;

        public readonly bool ContainsValue(float value, InclusionType1D inclusionType = InclusionType1D.BothSides) => inclusionType switch
        {
            InclusionType1D.NeitherSide => value > Start && value < End,
            InclusionType1D.LeftSide => value >= Start && value < End,
            InclusionType1D.RightSide => value > Start && value <= End,
            InclusionType1D.BothSides => value >= Start && value <= End,
            _ => throw FastExeptions.NonExistentEnumValue<InclusionType1D>(),
        };
    }
}