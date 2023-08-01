using AutoMapper;
using BusinessLogic.DTOs.Interfaces;
using BusinessLogic.Interfaces.Base;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Base
{
    public class Service<CreateDTO, UpdateDTO, ReadDTO, T> : IService<CreateDTO, UpdateDTO, ReadDTO, T>
        where CreateDTO : class, IDTO, new()
        where UpdateDTO : class, IUpdateDTO, new()
        where ReadDTO : class, IDTO, new()
        where T : class
    {
        private readonly IMapper _mapper;
        private readonly IUOW _uow;

        public Service(IMapper mapper, IUOW uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CreateDTO> CreateAsync(CreateDTO dto)
        {
            var createdEntity = _mapper.Map<T>(dto);
            await _uow.GetRepository<T>().CreateAsync(createdEntity);
            await _uow.SaveChangesAsync();
            return _mapper.Map<CreateDTO>(createdEntity);
        }

        public async Task<List<ReadDTO>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ReadDTO>>(data);
            return dto;
        }

        public async Task<IDTO> GetByIdAsync<IDTO>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByIdAsync(id);
            var dto = _mapper.Map<IDTO>(data);
            return dto;
        }

        public async Task<T> UpdateAsync(UpdateDTO dto)
        {
            var oldEntity = await _uow.GetRepository<T>().GetByIdAsync(dto.Id);
            if (oldEntity != null)
            {
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Update(entity, oldEntity);
                await _uow.SaveChangesAsync();
            }
            return oldEntity;
        }

        public async Task<T> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().GetByIdAsync(id);
            if (data != null)
            {
                _uow.GetRepository<T>().Remove(data);
                await _uow.SaveChangesAsync();
            }
            return data;
        }
    }
}
