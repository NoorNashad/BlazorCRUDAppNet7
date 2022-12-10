using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class StudentEntity
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
