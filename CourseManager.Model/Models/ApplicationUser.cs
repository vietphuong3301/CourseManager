using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CourseManager.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(256)]
        public string FullName { set; get; }

        [MaxLength(256)]
        public string Address { set; get; }

        public DateTime? BirthDay { set; get; }

        public virtual IEnumerable<Enroll> Enrolls { set; get; }

        public async Task<ClaimsPrincipal> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, IUserClaimsPrincipalFactory<ApplicationUser> claimsPrincipalFactory)
        {
            var userIdentity = await claimsPrincipalFactory.CreateAsync(this);

            return userIdentity;
        }
    }
}