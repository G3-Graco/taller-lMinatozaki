using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppBlazor.Data.Models
{
    public class UserDTO
    {
        public string UserName { get; set; } = string.Empty;

        public string Password {get; set;} = string.Empty;
    }
}