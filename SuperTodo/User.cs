using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTodo
{
   public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
