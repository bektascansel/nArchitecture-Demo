using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules:BaseBusinessRules
    {
        private readonly IBrandRepository _repository;

        public BrandBusinessRules(IBrandRepository repository)
        {
            _repository = repository;
        }


        public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
        {
            Brand? result = await _repository.GetAsync(predicate: b => b.Name.ToLower() == name.ToLower());
           
            if (result != null)
            {
                throw new BusinessException(BrandsMessages.BrandNameExists);
            }

        }
    }
}
