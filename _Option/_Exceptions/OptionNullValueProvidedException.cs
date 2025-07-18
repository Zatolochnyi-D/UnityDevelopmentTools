using System;

namespace ThreeDent.DevelopmentTools.Option.Exceptions
{
    [Serializable]
    public class OptionNullValueProvidedException : Exception
    {
        public OptionNullValueProvidedException() { }
        public OptionNullValueProvidedException(string message) : base(message) { }
        public OptionNullValueProvidedException(string message, Exception inner) : base(message, inner) { }
        protected OptionNullValueProvidedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}