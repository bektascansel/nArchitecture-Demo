﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class FuelRepository : EfRespositoryBase<Fuel, Guid, BaseDbContext>, IFuelRepository
    {
        public FuelRepository(BaseDbContext context) : base(context)
        {

        }
    }



}

