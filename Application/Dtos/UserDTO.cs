using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserRegisterDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class UserLoginDTO
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

    }
}
