using MaximaTech.Backend.Modules.v1.Produtos.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;

namespace MaximaTech.Backend.Modules.v1.Produtos._03_Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly string? _connectionString;

    public ProdutoRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Produto>> GetAll()
    {
        await using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
        string sql = @"SELECT 
                        p.id, 
                        p.codigo, 
                        p.descricao, 
                        p.departamento_id AS ""DepartamentoId"", 
                        p.preco, 
                        p.status, 
                        p.criado_em, 
                        d.codigo AS ""DepartamentoCodigo"", 
                        d.nome AS ""DepartamentoNome""
                    FROM produtos p
                    JOIN departamentos d ON d.id = p.departamento_id
                    WHERE p.status = TRUE";
        IEnumerable<Produto> produtos = await conn.QueryAsync<Produto>(sql);
        return produtos;
    }

    public async Task<Produto> GetById(Guid id)
    {
        await using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
        string sql = @"SELECT 
                        p.id, 
                        p.codigo, 
                        p.descricao, 
                        p.departamento_id AS ""DepartamentoId"", 
                        p.preco, 
                        p.status, 
                        p.criado_em, 
                        d.codigo AS ""DepartamentoCodigo"", 
                        d.nome AS ""DepartamentoNome""
                    FROM produtos p
                    JOIN departamentos d ON d.id = p.departamento_id
                    WHERE p.status = TRUE";
        IEnumerable<Produto> produtos = await conn.QueryAsync<Produto>(sql, new { Id = id });
        return produtos.FirstOrDefault() ?? new Produto();
    }

    public async Task<Produto> Create(Produto model)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        model.Id = Guid.NewGuid();
        model.CriadoEm = DateTime.Now;
        model.Status = true;
        string sql = @"INSERT INTO produtos (id, codigo, descricao, departamento_id, preco, status, criado_em)
                    VALUES (@Id, @Codigo, @Descricao, @DepartamentoId, @Preco, @Status, @CriadoEm)";
        await conn.ExecuteAsync(sql, model);
        return model;
    }

    public async Task<int> Update(Produto model)
    {
        await using var conn = new NpgsqlConnection(_connectionString);
        string sql = @"UPDATE produtos SET codigo=@Codigo, descricao=@Descricao, departamento_id=@DepartamentoId,
                    preco=@Preco, atualizado_em=NOW() WHERE id=@Id";
        return await conn.ExecuteAsync(sql, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        await using var conn = new NpgsqlConnection(_connectionString);
        string sql = @"UPDATE produtos SET status=FALSE, atualizado_em=NOW() WHERE id=@id";
        return await conn.ExecuteAsync(sql, new { id }) > 0;
    }
}