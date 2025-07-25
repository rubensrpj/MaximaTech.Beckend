using MaximaTech.Backend.Modules.v1.Departamento._03_Repositories;
using MaximaTech.Backend.Modules.v1.Produtos.Model;

namespace MaximaTech.Backend.Modules.v1.Departamento._02_Services;


public class DepartamentoService : IDepartamentoService
{
    private readonly IDepartamentoRepository _repo;

    public DepartamentoService(IDepartamentoRepository repository)
    {
        _repo = repository;
    }

    public async Task<IEnumerable<Model.Departamento>> GetAll()
    {
        return await _repo.GetAll();
    }

    public Task<Produto> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Produto> Create(Model.Departamento model)
    {
        throw new NotImplementedException();
    }

    public bool Update(Model.Departamento model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
