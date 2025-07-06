using System;
using UnityEngine;

namespace ThreeDent.DevelopmentTools
{
    [AttributeUsage(AttributeTargets.Field)]
    public class OnParentAttribute : Attribute
    {
        private int offset;

        public int Offset => offset;

        public OnParentAttribute()
        {
            offset = 0;
        }

        public OnParentAttribute(int offset)
        {
            this.offset = offset;
        }
    }
}