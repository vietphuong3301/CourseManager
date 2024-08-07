using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Model.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
        }

        [StringLength(250)]
        public string Description { set; get; }
    }
}