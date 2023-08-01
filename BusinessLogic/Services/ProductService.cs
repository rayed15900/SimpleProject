using AutoMapper;
using BusinessLogic.DTOs.ProductDTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.Base;
using BusinessLogic.Services.Base;
using DataAccess.UnitOfWork;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductService : Service<ProductCreateDTO, ProductUpdateDTO, ProductReadDTO, Product>, IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUOW _uow;

        public ProductService(IMapper mapper, IUOW uow) : base(mapper, uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
    }
}
