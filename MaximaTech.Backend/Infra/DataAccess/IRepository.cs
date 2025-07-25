using MaximaTech.Backend.Modules.v1.Produtos.Model;

namespace MaximaTech.Backend.Infra.DataAccess;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(Guid id);
    Task<T> Create(T model);
    Task<int> Update(T model);
    Task<bool> Delete(Guid id);
}
