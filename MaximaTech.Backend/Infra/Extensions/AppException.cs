using System.Globalization;

namespace MaximaTech.Infra.Extensions;

// classe de exceção personalizada para lançar exceções específicas da API (por exemplo, validação)

public class AppException : Exception
{
    public AppException()
    {
    }

    public AppException(string message) : base(message)
    {
    }

    public AppException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}