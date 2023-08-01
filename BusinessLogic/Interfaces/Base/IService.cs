using BusinessLogic.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Base
{
    public interface IService<CreateDTO, UpdateDTO, ReadDTO, T>
        where CreateDTO : class, IDTO, new()
        where UpdateDTO : class, IUpdateDTO, new()
        where ReadDTO : class, IDTO, new()
        where T : class
    {
        Task<CreateDTO> CreateAsync(CreateDTO dto);
        Task<List<ReadDTO>> GetAllAsync();
        Task<IDTO> GetByIdAsync<IDTO>(int id);
        Task<T> UpdateAsync(UpdateDTO dto);
        Task<T> RemoveAsync(int id);
    }
}
