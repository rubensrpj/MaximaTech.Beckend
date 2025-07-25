namespace MaximaTech.Infra.Exceptions;

[Serializable]
public class MaximaTechException : Exception
{
    public MaximaTechException(string message) : base(message) { }

    public MaximaTechException(string message, dynamic info)
        : base(message)
    {
        Info = info;
    }

    public MaximaTechException(string message, Exception innerException, dynamic info)
        : base(message, innerException)
    {
        Info = info;
    }

    public dynamic? Info { get; set; }
}
