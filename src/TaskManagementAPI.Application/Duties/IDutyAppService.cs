using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAPI.Duties.Dto;
using TaskManagementAPI.Tasks.Dto;
using TaskManagementAPI.Users.Dto;

namespace TaskManagementAPI.Duties
{
    public interface IDutyAppService
    {
        Task<DutyDto> CreateDutyAsync(CreateDutyDto input);

        Task<DutyDto> UpdateDutyAsync(Guid id, DutyDto input);
        Task DeleteDutyAsync(Guid id);
        Task<DutyDto> GetDutyByIdAsync(Guid id);
        Task<PagedResultDto<DutyDto>> GetDutiesAsync(DutyFilterDto filter);
        Task AssignDutyAsync(AssignDutyDto input); 

    }
}
