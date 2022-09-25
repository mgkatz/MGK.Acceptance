namespace MGK.Acceptance.Test;

public class TestArgumentException : ArgumentException
{
    public TestArgumentException() : base()
    {
    }

    public TestArgumentException(string message) : base(message)
    {
    }

    public TestArgumentException(string message, Exception innerException) : base(message, innerException)
    {
    }
}