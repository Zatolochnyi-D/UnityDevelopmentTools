using System;

namespace ThreeDent.DevelopmentTools
{
    [AttributeUsage(AttributeTargets.Field)]
    public class OnThisAttribute : Attribute
    {
        private int index;

        public int Index => index;

        public OnThisAttribute()
        {
            index = 0;
        }

        public OnThisAttribute(int index)
        {
            this.index = index;
        }
    }
}