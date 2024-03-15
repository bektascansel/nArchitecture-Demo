using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ModelRepository : EfRespositoryBase<Model, Guid, BaseDbContext>, IModelRepository
    {
        public ModelRepository(BaseDbContext context) : base(context)
        {

        }
    }



}

