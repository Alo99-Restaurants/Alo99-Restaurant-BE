public class ClientException : Exception
{
    public string? Code { get; }
    public ClientException()
    {
    }
    public ClientException(string message, string code) : base(message)
    {
        Code = code;
    }
    public ClientException(string message)
        : base(message)
    {
    }

    public ClientException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
