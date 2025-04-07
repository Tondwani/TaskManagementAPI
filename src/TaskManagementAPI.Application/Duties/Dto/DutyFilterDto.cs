using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAPI.Dutys;

namespace TaskManagementAPI.Duties.Dto
{
    [AutoMap(typeof(Duty))]
    public class DutyFilterDto : PagedAndSortedResultRequestDto
    {

        public string Status { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? AssignedUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Comments { get; set; }

        public string Keyword { get; set; }
    }
}
