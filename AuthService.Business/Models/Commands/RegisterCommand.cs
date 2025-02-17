using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Business.Models.Commands
{
    public record RegisterCommand
    {  
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
