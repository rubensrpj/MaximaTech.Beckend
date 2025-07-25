using Mapster;
using System.Text.Json.Nodes;
using MaximaTech.Infra.Exceptions;

namespace MaximaTech.Backend.Infra.Constants;

public class ErrorModel
{
    public bool Success { get; set; } = false;
    public string Name { get; init; } = "";
    public int Code { get; set; }
    public string Message { get; set; } = "";
    public dynamic? Detail { get; set; }
    public dynamic? Info { get; set; }
}

internal static class AppErrorList
{
    public static ErrorModel FindByName(string name, params object[] args)
    {
        var listError = Errors.Where(e => e.Name == name).ToList();

        if (!listError.Any())
        {
            return new ErrorModel();
        }

        // utiliza o adapt para criar uma cópia do objeto e não uma referência
        var error = listError.First().Adapt<ErrorModel>();

        error.Message = string.Format(error.Message, args);

        return error;
    }

    public static ErrorModel FindByName(string name, MaximaTechException err, params object[] args)
    {
        var listError = Errors.Where(e => e.Name == name).ToList();

        if (!listError.Any())
        {
            return new ErrorModel();
        }

        // utiliza o adapt para criar uma cópia do objeto e não uma referência
        var error = listError.First().Adapt<ErrorModel>();

        error.Message = string.Format(error.Message, args);
        try
        {
            error.Detail = JsonNode.Parse(err.Message);
        }
        catch
        {
            error.Detail = err.Message;
        }

        error.Info = err.Info;

        return error;
    }

    private static IEnumerable<ErrorModel> Errors { get; set; } = new List<ErrorModel>
    {
        new() { Name = "USER_OR_PASSWORD_INVALID", Code = 901, Message = "Usuário ou senha inválidos. Verifique os dados informados e tente novamente." },
        new() { Name = "EMAIL_NOT_VERIFIED", Code = 902, Message = "O e-mail do usuário não foi validado. Verifique sua caixa de entrada." },
        new() { Name = "PHONE_NOT_VERIFIED", Code = 903, Message = "O número de telefone do usuário não foi validado" },
        new() { Name = "EMAIL_ALREADY_EXISTS", Code = 904, Message = "Este e-mail já existe em nossa base de dados para outro usuário ( {0} )" },
        new() { Name = "TOKEN_NOT_INFORMED", Code = 905, Message = "Token não informado ou informado incorretamente" },
        new() { Name = "ACCESS_OR_REFRESH_TOKEN_INVALID", Code = 906, Message = "Verifique o access token e o refresh token" },
        new() { Name = "NOT_FOUND", Code = 907, Message = "{0} não encontrado(a) {1}" },
        new() { Name = "EMAIL_VERIFY_ERROR", Code = 908, Message = "Erro na validação do e-mail" },
        new() { Name = "EMAIL_ALREADY_VERIFIED", Code = 909, Message = "O e-mail do usuário já foi validado" },
        new() { Name = "EMAIL_CHANGE_IS_NULL", Code = 910, Message = "O novo e-mail do usuário não foi informado" },
        new() { Name = "SAME_ID_REQUEST", Code = 911, Message = "O {0} {1} deve ser igual ao {0} da requisição!" },
        new() { Name = "USER_INSERT_ERROR", Code = 912, Message = "Erro ao inserir o usuário" },
        new() { Name = "UPLOAD_ERROR", Code = 913, Message = "Erro ao fazer upload {0}" },
        new() { Name = "MOBILE_PHONE_VERIFY_ERROR", Code = 914, Message = "Erro na validação do telefone" },
        new() { Name = "MOBILE_PHONE_ALREADY_VERIFIED", Code = 915, Message = "O telefone do usuário já foi validado" },
        new() { Name = "EMAIL_CODE_INVALID", Code = 916, Message = "Código de verificação do e-mail inválido" },
        new() { Name = "COUPON_EXPIRED", Code = 917, Message = "Cupom expirado" },
        new() { Name = "COUPON_MAX_USE", Code = 918, Message = "A quantidade máxima de uso deste cupom foi atingida" },
        new() { Name = "COUPON_MIN_ORDER_AMOUNT", Code = 919, Message = "Cupom não se aplica a esse valor de pedido. Valor mínimo: {0}" },
        new() { Name = "NOT_ACTIVE", Code = 920, Message = "{0} não está ativo" },
        new() { Name = "TOKEN_OWNER", Code = 921, Message = "Owner diferente do token. Informe o mesmo Owner do token JWT" },
        new() { Name = "JWT_ID_NOT_FOUND", Code = 922, Message = "Erro ao ler o access token: ID não encontrado." },
        new() { Name = "EMPTY_AVATAR", Code = 923, Message = "O usuário não possui avatar" },
        new() { Name = "DELETE_ERROR", Code = 924, Message = "Erro ao deletar {0}" },
        new() { Name = "PAYMENTCARD_ZEROAUTH", Code = 925, Message = "Falha na validação do cartão" },
        new() { Name = "PAYMENTCARD_TOKENIZE", Code = 926, Message = "Falha na tokenização do cartão" },
        new() { Name = "PAYMENTCARD_NOT_ACCEPTED", Code = 927, Message = "Cartão de Bandeira não aceita" },
        new() { Name = "PAYMENTCARD_QUERY_BIN_ERROR", Code = 928, Message = "Não foi possível consultar o Bin informado: {0}" },
        new() { Name = "ACCOUNT_NOT_FOUND", Code = 929, Message = "Usuário ainda não possui uma conta criada" },
        new() { Name = "ACCOUNT_NOT_ACTIVE", Code = 930, Message = "A conta do usuário não está ativa" },
        new() { Name = "ACCOUNT_ALREADY_EXISTS", Code = 931, Message = "A conta do usuário não está ativa" },
        new() { Name = "ORDER_CREATE_ERROR", Code = 932, Message = "Erro ao gravar pedido" },
        new() { Name = "CHARGE_CREATE_INVALID_STATUS", Code = 933, Message = "O status de pagamento do pedido não permite nova tentativa" },
        new() { Name = "DEVICE_ID_ERROR", Code = 934, Message = "O deviceId enviado no login não corresponde ao deviceId cadastrado na conta" },
        new() { Name = "TRANSPORT_CARD_ALREADY_EXIST", Code = 935, Message = "Cartão de Transporte já cadastrado nessa conta." },
        new() { Name = "REFRESH_TOKEN_INVALID", Code = 936, Message = "Refresh token não encontrado. Verifique se o refresh token informado está correto." },
        new() { Name = "CPF_ALREADY_EXISTS", Code = 937, Message = "Este CPF já existe em nossa base de dados para outro usuário ( {0} )" },
        new() { Name = "TICKET_NOT_EXIST", Code = 938, Message = "Esse ticket não existe em nossa base de dados" },
        new() { Name = "TICKET_OWNED_BY_ANOTHER_ACCOUNT", Code = 939, Message = "Esse ticket não pertence a essa conta" },
        new() { Name = "TICKET_ALREADY_ACTIVATED", Code = 940, Message = "Esse ticket já foi ativado" },
        new() { Name = "FILE_EMPTY", Code = 941, Message = "Arquivo não enviado" },
        new() { Name = "JSON_EMPTY", Code = 942, Message = "Json não enviado" },
        new() { Name = "FILE_UPLOAD_ERROR", Code = 943, Message = "Erro ao fazer upload do arquivo" },
        new() { Name = "DEVICE_ALREADY_EXISTS", Code = 944, Message = "Este DeviceId já existe em nossa base ( {0} )" },
    };
}
