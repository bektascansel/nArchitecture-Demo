using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetById
{
    public class GetByIdBrandQuery:IRequest<GetByIdBrandResponse>
    {

        public Guid Id { get; set; }

        public GetByIdBrandQuery(Guid id)
        {
            Id = id;
        
        }

        public class GetByIdBrandQueryHandler:IRequestHandler<GetByIdBrandQuery,GetByIdBrandResponse>
        {

            private readonly IMapper _mapper;
            private readonly IBrandRepository _repository;

            public GetByIdBrandQueryHandler(IMapper mapper, IBrandRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<GetByIdBrandResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Brand brand = await _repository.GetAsync(predicate: b => b.Id == request.Id,withDeleted:true,cancellationToken:cancellationToken);

                GetByIdBrandResponse response=_mapper.Map<GetByIdBrandResponse>(brand);

                return response;
            }
        }



    }
}
