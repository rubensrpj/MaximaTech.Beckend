---
to: Modules/v1/<%= Name %>s/02-Services/<%= Name %>Service.cs
---

using GestCom.Backend.Modules.v1.<%= Name %>s._03_Repositories;
using GestCom.Backend.Modules.v1.<%= Name %>s.Model;

namespace GestCom.Backend.Modules.v1.<%= Name %>s._02_Services;


public class <%= Name %>Service : I<%= Name %>Service
{
    private readonly I<%= Name %>Repository _repo;

    public <%= Name %>Service(I<%= Name %>Repository repository)
    {
        _repo = repository;
    }

    public IQueryable<<%= Name %>> GetAll()
    {
        return _repo.GetAll();
    }

    public <%= Name %> GetById(uint id)
    {
        var response = _repo.GetByCondition(p => p.Id == id);
        if (!response.Any())
        {
            return new <%= Name %>();
        }
        return response.First();
    }

    public <%= Name %> Create(<%= Name %> model)
    {
        return _repo.Create(model);
    }
    
    public bool Update(<%= Name %>UpdateDto <%= name %>UpdateDto)
    {
        var <%= name %>ToUpdate = GetById(<%= name %>UpdateDto.Id);

        if (<%= name %>ToUpdate.Id == 0 && string.IsNullOrEmpty(<%= name %>ToUpdate.Name))
            return false;

        <%= name %>UpdateDto.Adapt(<%= name %>ToUpdate);

        return _repo.Update(<%= name %>ToUpdate) > 0;
    }

    public bool Update(<%= Name %> <%= name %>)
    {
        throw new NotImplementedException();
    }
    
    public bool Delete(uint id)
    {
        var <%= name %> = _repo.GetByCondition(p => p.Id == id);
        if (!<%= name %>.Any())
        {
            return false;
        }

        return _repo.Delete(<%= name %>.First());
    }

    public IQueryable<<%= Name %>> GetByCondition(Expression<Func<<%= Name %>, bool>> expression)
    {
        var response = _repo.GetByCondition(expression);
        return response;
    }

}
