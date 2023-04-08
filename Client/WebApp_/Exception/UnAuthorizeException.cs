using System.Runtime.Serialization;

namespace WebApp_.Exception

{
    public class UnAuthorizeException : System.Exception
    {
        public UnAuthorizeException()
        {
        }

        public UnAuthorizeException(string? message) : base(message)
        {
        }

        public UnAuthorizeException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected UnAuthorizeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
