using System;

namespace ThreeDent.DevelopmentTools
{
    [AttributeUsage(AttributeTargets.Field)]
    public class OnChildAttribute : Attribute
    {
        private readonly int offset;

        public int Offset => offset;

        public OnChildAttribute()
        {
            offset = 0;
        }

        public OnChildAttribute(int offset)
        {
            this.offset = offset;
        }
    }
}
