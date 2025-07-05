using System;

namespace ThreeDent.DevelopmentTools
{
    public enum OnChildTraversingMode
    {
        BFS,
        DFS,
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class OnChildAttribute : Attribute
    {
        private int offset;
        private OnChildTraversingMode traversingMode;

        public int Offset => offset;
        public OnChildTraversingMode TraversingMode => traversingMode;

        public OnChildAttribute(OnChildTraversingMode traversingMode = OnChildTraversingMode.BFS)
        {
            offset = 0;
            this.traversingMode = traversingMode;
        }

        public OnChildAttribute(int index, OnChildTraversingMode traversingMode = OnChildTraversingMode.BFS)
        {
            this.offset = index;
            this.traversingMode = traversingMode;
        }
    }
}
