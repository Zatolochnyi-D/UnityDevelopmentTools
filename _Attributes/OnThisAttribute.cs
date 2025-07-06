using System;

namespace ThreeDent.DevelopmentTools.Attributes
{
    /// <summary>
    /// Marks field to be filled with first matching component on this object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class OnThisAttribute : Attribute
    {
        private int index;

        public int Index => index;

        public OnThisAttribute()
        {
            index = 0;
        }

        /// <summary></summary>
        /// <param name="index">Defines how many matching components to skip. Skips first N matching components.</param>
        public OnThisAttribute(int index)
        {
            this.index = index;
        }
    }
}