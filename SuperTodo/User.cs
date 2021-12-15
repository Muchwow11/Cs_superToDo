using Microsoft.AspNetCore.Identity;

namespace SuperTodo
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
