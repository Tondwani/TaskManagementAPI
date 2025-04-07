using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementAPI.Users.Dto
{
    public class UserOtpDto
    {
        public Guid UserId { get; set; }
        public string OtpCode { get; set; }
    }
}
