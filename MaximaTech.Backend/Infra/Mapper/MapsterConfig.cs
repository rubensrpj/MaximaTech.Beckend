using Microsoft.Extensions.Primitives;
using System.Reflection;
using Mapster;

namespace MaximaTech.Backend.Infra.Mapper;

public static class MapsterConfig
{
    public static void RegisterMapsterConfiguration()
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);
        TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

        TypeAdapterConfig<long?, DateOnly?>.NewConfig()
            .MapWith(src => src.HasValue
                ? DateOnly.FromDateTime(DateTime.ParseExact(src.Value.ToString(), "ddMMyyyy", CultureInfo.InvariantCulture))
                : (DateOnly?)null);
        TypeAdapterConfig<int?, DateOnly?>.NewConfig()
            .MapWith(src => src.HasValue
                ? DateOnly.FromDateTime(DateTime.ParseExact(src.Value.ToString(), "ddMMyyyy", CultureInfo.InvariantCulture))
                : (DateOnly?)null);
        TypeAdapterConfig<uint?, DateOnly?>.NewConfig()
            .MapWith(src => src.HasValue
                ? DateOnly.FromDateTime(DateTime.ParseExact(src.Value.ToString(), "ddMMyyyy", CultureInfo.InvariantCulture))
                : (DateOnly?)null);




        TypeAdapterConfig<DateTime?, DateOnly?>.NewConfig().MapWith(src => src == null ? null : DateOnly.FromDateTime((DateTime)src));

        TypeAdapterConfig<string?, DateOnly?>.NewConfig().MapWith(src => string.IsNullOrEmpty(src) ? null : DateOnly.FromDateTime(DateTime.Parse(src)));

        TypeAdapterConfig<StringValues, DateOnly?>.NewConfig()
            .MapWith(src => string.IsNullOrEmpty(src.ToString()) ? null : DateOnly.FromDateTime(DateTime.Parse(src.ToString())));
    }
}

