using System;

namespace ThreeDent.DevelopmentTools
{
    public enum TraversingMode
    {
        BFS,
        DFS,
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class OnChildAttribute : Attribute
    {
        private int offset;
        private TraversingMode traversingMode;

        public int Offset => offset;
        public TraversingMode TraversingMode => traversingMode;

        public OnChildAttribute(TraversingMode traversingMode = TraversingMode.BFS)
        {
            offset = 0;
            this.traversingMode = traversingMode;
        }

        public OnChildAttribute(int index, TraversingMode traversingMode = TraversingMode.BFS)
        {
            this.offset = index;
            this.traversingMode = traversingMode;
        }
    }
}
