using System;

namespace ThreeDent.DevelopmentTools.ReferencingAttributes
{
    /// <summary>
    /// Marks field to be filled with first parent that has this Component.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class OnParentAttribute : Attribute
    {
        private readonly int offset;

        public int Offset => offset;

        public OnParentAttribute()
        {
            offset = 0;
        }

        /// <summary></summary>
        /// <param name="offset">Defines how much matching parents should be skipped. Search will skip first N parents with matching components.</param>
        public OnParentAttribute(int offset)
        {
            this.offset = offset;
        }
    }
}