using MaximaTech.Backend.Modules.v1.Produtos.Model;

namespace MaximaTech.Backend.Infra.DataAccess;

public interface IService<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<Produto> GetById(Guid id);
    Task<Produto> Create(T model);
    bool Update(T model);
    Task<bool> Delete(Guid id);
}
