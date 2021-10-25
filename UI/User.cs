using Microsoft.AspNetCore.Identity;


namespace UI
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
