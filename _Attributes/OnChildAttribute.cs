using System;

namespace ThreeDent.DevelopmentTools.Attributes
{
    /// <summary>
    /// Marks field to be filled with first matching component on one of this object's children.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class OnChildAttribute : Attribute
    {
        private int offset;
        private TraversingMode traversingMode;

        public int Offset => offset;
        public TraversingMode TraversingMode => traversingMode;

        /// <summary></summary>
        /// <param name="traversingMode">Defines how to unfold children hierarchy</param>
        public OnChildAttribute(TraversingMode traversingMode = TraversingMode.BFS)
        {
            offset = 0;
            this.traversingMode = traversingMode;
        }

        /// <summary></summary>
        /// <param name="index">Defines how many matching children to skip. Skips first N matching children.</param>
        /// <param name="traversingMode">Defines how to unfold children hierarchy</param>
        public OnChildAttribute(int index, TraversingMode traversingMode = TraversingMode.BFS)
        {
            this.offset = index;
            this.traversingMode = traversingMode;
        }
    }
}
