using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand:IRequest<CreatedBrandResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
    {
        public string Name { get; set; }

        public string? CacheKey => "";

        public bool BypassCache => false;

        public string? CacheGroupKey => "GetBrands";
    }


    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository repository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _repository = repository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }



        public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {

            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

            Brand brand=_mapper.Map<Brand>(request);

            await _repository.AddAsync(brand);
          

            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);
            /*
            CreatedBrandResponse createdBrandResponse=new CreatedBrandResponse();
            createdBrandResponse.Name=result.Name;
            createdBrandResponse.Id = result.Id;
            */

            return createdBrandResponse;

        }
    }
}
