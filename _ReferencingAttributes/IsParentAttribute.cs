using System;

namespace ThreeDent.DevelopmentTools.ReferencingAttributes
{
    /// <summary>
    /// Marks field to be filled with first parent of this object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class IsParentAttribute : Attribute
    {
        private int index;

        public int Index => index;

        public IsParentAttribute()
        {
            index = 0;
        }

        /// <summary></summary>
        /// <param name="index">Defines how many parents to skip. Skips first N parents.</param>
        public IsParentAttribute(int index)
        {
            this.index = index;
        }
    }
}