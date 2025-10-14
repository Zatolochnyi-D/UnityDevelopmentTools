using System;

namespace ThreeDent.DevelopmentTools.ReferencingAttributes
{
    /// <summary>
    /// Marks field to be filled with first child of this object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class IsChildAttribute : Attribute
    {
        private readonly int offset;
        private readonly TraversingMode traversingMode;

        public int Offset => offset;
        public TraversingMode TraversingMode => traversingMode;

        /// <summary></summary>
        /// <param name="traversingMode">Defines how to unfold children hierarchy</param>
        public IsChildAttribute(TraversingMode traversingMode = TraversingMode.BFS)
        {
            offset = 0;
            this.traversingMode = traversingMode;
        }

        /// <summary></summary>
        /// <param name="index">Defines how many children to skip. Skips first N children.</param>
        /// <param name="traversingMode">Defines how to unfold children hierarchy</param>
        public IsChildAttribute(int offset, TraversingMode traversingMode = TraversingMode.BFS)
        {
            this.offset = offset;
            this.traversingMode = traversingMode;
        }
    }
}