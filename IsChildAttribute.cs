using System;
using UnityEngine;

namespace ThreeDent.DevelopmentTools
{
    [AttributeUsage(AttributeTargets.Field)]
    public class IsChildAttribute : Attribute
    {
        private int offset;
        private TraversingMode traversingMode;

        public int Offset => offset;
        public TraversingMode TraversingMode => traversingMode;

        public IsChildAttribute(TraversingMode traversingMode = TraversingMode.BFS)
        {
            offset = 0;
            this.traversingMode = traversingMode;
        }

        public IsChildAttribute(int offset, TraversingMode traversingMode = TraversingMode.BFS)
        {
            this.offset = offset;
            this.traversingMode = traversingMode;
        }
    }
}