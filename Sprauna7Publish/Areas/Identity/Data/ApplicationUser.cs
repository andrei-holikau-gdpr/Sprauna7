using Microsoft.AspNetCore.Identity;


namespace Sprauna7Publish.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }

        public byte[]? ProfilePicture { get; set; }
    }
}
