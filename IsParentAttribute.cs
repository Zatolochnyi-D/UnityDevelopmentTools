using System;
using UnityEngine;

namespace ThreeDent.DevelopmentTools
{
    [AttributeUsage(AttributeTargets.Field)]
    public class IsParentAttribute : Attribute
    {
        private int index;

        public int Index => index;

        public IsParentAttribute()
        {
            index = 0;
        }

        public IsParentAttribute(int index)
        {
            this.index = index;
        }
    }
}