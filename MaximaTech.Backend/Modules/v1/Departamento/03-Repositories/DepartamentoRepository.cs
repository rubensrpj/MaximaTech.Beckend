using Dapper;
using MaximaTech.Backend.Infra.DataAccess;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MaximaTech.Backend.Modules.v1.Departamento._03_Repositories;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly string? _connectionString;
    public DepartamentoRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public Task<Model.Departamento> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Model.Departamento> Create(Model.Departamento model)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(Model.Departamento model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    async Task<IEnumerable<Model.Departamento>> IRepository<Model.Departamento>.GetAll()
    {
        await using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
        string sql = @"SELECT d.* FROM departamentos d";
        IEnumerable<Model.Departamento> departamentos = await conn.QueryAsync<Model.Departamento>(sql);
        return departamentos;
    }
}
