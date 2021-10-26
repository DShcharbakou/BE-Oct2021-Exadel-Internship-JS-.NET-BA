using Microsoft.AspNetCore.Identity;


namespace UI
{
   public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        override
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
