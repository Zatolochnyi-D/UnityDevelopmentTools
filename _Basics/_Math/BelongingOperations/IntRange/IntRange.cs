namespace DenZ.DevelopmentTools.Math
{
    public struct IntRange
    {
        public static implicit operator IntRange((int, int) tuple) => new(tuple);
        public static implicit operator (int, int)(IntRange range) => (range.Start, range.End);

        public int Start;
        public int End;

        public IntRange(int start, int end) => (Start, End) = (start, end);
        public IntRange((int, int) tupleRange) => (Start, End) = tupleRange;

        public readonly bool ContainsValue(int value, InclusionType1D inclusionType = InclusionType1D.LeftSide) => inclusionType switch
        {
            InclusionType1D.NeitherSide => value > Start && value < End,
            InclusionType1D.LeftSide => value >= Start && value < End,
            InclusionType1D.RightSide => value > Start && value <= End,
            InclusionType1D.BothSides => value >= Start && value <= End,
            _ => throw FastExeptions.NonExistentEnumValue<InclusionType1D>(),
        };
    }
}