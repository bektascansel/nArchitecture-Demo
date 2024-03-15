using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Persistence.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand:IRequest<UpdatedBrandResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string? CacheKey => "";

        public bool BypassCache => false;

        public string? CacheGroupKey => "GetBrands";

        public class UpdateBrandRepositoryHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
        {

            private readonly IMapper _mapper;
            private readonly IBrandRepository _repository;

            public UpdateBrandRepositoryHandler(IMapper mapper, IBrandRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
               Brand? brand=await _repository.GetAsync(predicate:p=>p.Id==request.Id, cancellationToken:cancellationToken);

                brand = _mapper.Map(request, brand);

                await _repository.UpdateAsync(brand);

               UpdatedBrandResponse updatedBrandResponse= _mapper.Map<UpdatedBrandResponse>(brand);

                return updatedBrandResponse;
            }
        }
    }
}
