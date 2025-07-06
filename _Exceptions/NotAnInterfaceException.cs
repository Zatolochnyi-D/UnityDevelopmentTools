namespace ThreeDent.DevelopmentTools.Exceptions
{
    [System.Serializable]
    public class NotAnInterfaceException : System.Exception
    {
        public NotAnInterfaceException() { }
        public NotAnInterfaceException(string message) : base(message) { }
        public NotAnInterfaceException(string message, System.Exception inner) : base(message, inner) { }
        protected NotAnInterfaceException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}