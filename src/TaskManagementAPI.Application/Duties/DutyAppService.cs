using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementAPI.Duties.Dto;
using TaskManagementAPI.Dutys;
using TaskManagementAPI.Tasks.Dto;
using TaskManagementAPI.Users.Dto;

namespace TaskManagementAPI.Duties
{
    public class DutyAppService : ApplicationService, IDutyAppService
    {
        private readonly IRepository<Duty, Guid> _dutyRepository;
        private readonly IObjectMapper _objectMapper;

        public DutyAppService(IRepository<Duty, Guid> dutyRepository, IObjectMapper objectMapper)
        {
            _dutyRepository = dutyRepository;
            _objectMapper = objectMapper;
        }

        [AbpAuthorize("Duty.Create")]
        public async Task<DutyDto> CreateDutyAsync(CreateDutyDto input)
        {
            try
            {
                var duty = _objectMapper.Map<Duty>(input);
                await _dutyRepository.InsertAsync(duty);
                return _objectMapper.Map<DutyDto>(duty);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Failed to create duty", ex.Message);
            }
        }

        [AbpAuthorize("Duty.Update")]
        public async Task<DutyDto> UpdateDutyAsync(Guid id, DutyDto input)
        {
            try
            {
                var duty = await _dutyRepository.FirstOrDefaultAsync(id);
                if (duty == null)
                    throw new UserFriendlyException("Duty not found");

                _objectMapper.Map(input, duty);
                await _dutyRepository.UpdateAsync(duty);

                return _objectMapper.Map<DutyDto>(duty);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Failed to update duty", ex.Message);
            }
        }

        [AbpAuthorize("Duty.Delete")]
        public async Task DeleteDutyAsync(Guid id)
        {
            try
            {
                var duty = await _dutyRepository.FirstOrDefaultAsync(id);
                if (duty == null)
                    throw new UserFriendlyException("Duty not found");

                await _dutyRepository.DeleteAsync(duty);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Failed to delete duty", ex.Message);
            }
        }

        [AbpAuthorize("Duty.Create")]
        public async Task<DutyDto> GetDutyByIdAsync(Guid id)
        {
            try
            {
                var duty = await _dutyRepository.FirstOrDefaultAsync(id);
                if (duty == null)
                    throw new UserFriendlyException("Duty not found");

                return _objectMapper.Map<DutyDto>(duty);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Failed to retrieve duty", ex.Message);
            }
        }

        // Paganation method using the skip & take methods to handle the pagination, sorting  DutyFilterDto for dynamic sorting.
        public async Task<PagedResultDto<DutyDto>> GetDutiesAsync(DutyFilterDto filter)
        {
            try
            {
                var query = _dutyRepository.GetAll();

                // Apply filters
                if (!string.IsNullOrEmpty(filter.Status))
                {
                    if (Enum.TryParse(filter.Status, out DutyStatus status))
                    {
                        query = query.Where(d => d.Status == status);
                    }
                    else
                    {
                        throw new UserFriendlyException("Invalid duty status");
                    }
                }

                if (filter.DueDate.HasValue)
                {
                    query = query.Where(d => d.DueDate != null && d.DueDate.Value.Date == filter.DueDate.Value.Date);
                }

                if (filter.AssignedUserId.HasValue)
                {
                    query = query.Where(d => d.AssignedToUserId == filter.AssignedUserId);
                }

                if (!string.IsNullOrEmpty(filter.Title))
                {
                    query = query.Where(d => d.Title.Contains(filter.Title));
                }

                if (!string.IsNullOrEmpty(filter.Description))
                {
                    query = query.Where(d => d.Description.Contains(filter.Description));
                }

                if (filter.CreatedDate.HasValue)
                {
                    query = query.Where(d => d.CreationTime.Date == filter.CreatedDate.Value.Date);
                }

                if (!string.IsNullOrEmpty(filter.Comments))
                {
                    query = query.Where(d => d.Comments.Contains(filter.Comments));
                }

                // Apply sorting
                if (!string.IsNullOrEmpty(filter.Sorting))
                {
                    query = query.OrderBy(d => EF.Property<object>(d, filter.Sorting)); // Dynamic sorting
                }
                else
                {
                    query = query.OrderBy(d => d.CreationTime); // Default sorting by CreationTime
                }

                // Apply pagination
                var totalCount = await query.CountAsync();
                var duties = await query.Skip(filter.SkipCount).Take(filter.MaxResultCount).ToListAsync();

                var dutyDtos = _objectMapper.Map<List<DutyDto>>(duties);
                return new PagedResultDto<DutyDto>(totalCount, dutyDtos);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Failed to retrieve duties", ex.Message);
            }
        }



        public async Task AssignDutyAsync(AssignDutyDto input)
        {
            try
            {
                var duty = await _dutyRepository.FirstOrDefaultAsync(input.DutyId);
                if (duty == null)
                    throw new UserFriendlyException("Duty not found");

                duty.AssignedToUserId = input.UserId;
                //duty.AssignedToUserName = input.us;

                await _dutyRepository.UpdateAsync(duty);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Failed to assign duty", ex.Message);
            }
        }
    }
}
