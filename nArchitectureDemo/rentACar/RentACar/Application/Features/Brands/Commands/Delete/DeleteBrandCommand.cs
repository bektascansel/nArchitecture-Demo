using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand:IRequest<DeletedBrandResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public string? CacheKey => "";

        public bool BypassCache => false;

        public string? CacheGroupKey => "GetBrands";

        public DeleteBrandCommand(Guid id)
        {
            Id = id;
        }


        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
        {

            private readonly IMapper _mapper;
            private readonly IBrandRepository _repository;

            public DeleteBrandCommandHandler(IMapper mapper, IBrandRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand= await _repository.GetAsync(predicate: p=>p.Id==request.Id,cancellationToken:cancellationToken);

               await _repository.DeleteAsync(brand);


                DeletedBrandResponse deletedBrandResponse=_mapper.Map<DeletedBrandResponse>(brand);

                return deletedBrandResponse;
               
             


            }
        }

    }
}
