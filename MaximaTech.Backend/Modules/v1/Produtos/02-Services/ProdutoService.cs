using MaximaTech.Backend.Modules.v1.Produtos._03_Repositories;
using MaximaTech.Backend.Modules.v1.Produtos.Model;

namespace MaximaTech.Backend.Modules.v1.Produtos._02_Services;


public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repo;

    public ProdutoService(IProdutoRepository repository)
    {
        _repo = repository;
    }

    public async Task<IEnumerable<Produto>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<Produto> GetById(Guid id)
    {
        Produto response = await _repo.GetById(id);
        return response;
    }

    public async Task<Produto> Create(Produto model)
    {
        return await _repo.Create(model);
    }

    public bool Update(Produto model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(ProdutoUpdateDto produtoUpdateDto)
    {
        Produto produtoToUpdate = await GetById(produtoUpdateDto.Id);

        if (produtoToUpdate.Id == Guid.Empty)
            return false;

        produtoUpdateDto.Adapt(produtoToUpdate);

        return await _repo.Update(produtoToUpdate) > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
            Produto produto = await _repo.GetById(id);
        if (produto.Id == Guid.Empty)
            return false;
        return await _repo.Delete(produto.Id);
    }

}
