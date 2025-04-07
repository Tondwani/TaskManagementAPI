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
    public class AddCommentDto
    {
        public Guid DutyId { get; set; }
        public string Comment { get; set; }
        public string CommenterName { get; set; }
    }
}
