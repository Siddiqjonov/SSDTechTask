using FluentValidation.Results;
using System.Runtime.Serialization;

namespace WebApiA.Exceptions;

[Serializable]
public class ValidationFailedException : BaseException
{
    public ValidationFailedException() { }
    public ValidationFailedException(String message) : base(message) { }
    public ValidationFailedException(String message, Exception inner) : base(message, inner) { }
    protected ValidationFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
