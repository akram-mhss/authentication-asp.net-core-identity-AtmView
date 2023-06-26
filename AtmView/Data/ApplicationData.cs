using Microsoft.AspNetCore.Identity;

namespace AtmView.Data
{
    public class ApplicationData : IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
