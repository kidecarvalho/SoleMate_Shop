using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SoleMate.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
    }
}
