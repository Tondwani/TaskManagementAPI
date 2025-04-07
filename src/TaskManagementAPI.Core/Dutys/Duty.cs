using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAPI.Authorization.Users;

namespace TaskManagementAPI.Dutys
{
    public enum DutyStatus
    {
        New,
        InProgress,
        Completed,
        OnHold
    }
    public class Duty : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DutyStatus Status { get; set; }
        public string Comments { get; set; }

        // Navigation properties
        public Guid AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; }

        public Guid CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string AssignedToUserName { get; set; }
    }
}
