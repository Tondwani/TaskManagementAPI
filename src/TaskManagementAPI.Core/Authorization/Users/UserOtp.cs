using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementAPI.Authorization.Users
{
    public class UserOtp
    {
        public Guid UserId { get; set; }
        public string OtpCode { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool IsVerified { get; set; }
    }
}
