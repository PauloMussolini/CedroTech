using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedroTechApi.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public DateTime? BornDate { get; set; }

        public string RG { get; set; }
        public string CPF { get; set; }
    }
}
