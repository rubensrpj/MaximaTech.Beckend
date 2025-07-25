using Mapster;

namespace MaximaTech.Backend.Infra;

public class CodeGenerationConfig : ICodeGenerationRegister
{
    public void Register(global::Mapster.CodeGenerationConfig config)
    {
        // config.AdaptTo("[name]DTO")
        //     .ForType<Product>();
        //.ForType<Address>();

        //config.GenerateMapper("[name]Mapper")
        //    .ForType<Person>()
        //    .ForType<Address>();
    }
}