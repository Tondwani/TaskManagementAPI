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
    public class CreateDutyDto
    {
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DutyStatus Status { get; set; }
        public string Comments { get; set; }
        public Guid AssignedToUserId { get; set; }
        public string AssignedToUserName { get; set; }
        public Guid CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
    }
}
