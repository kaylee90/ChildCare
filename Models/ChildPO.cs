using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChildCare.Models
{
    public class ChildPO
    {
        public Int64 ChildID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Age")]
        public string Age { get; set; }

        [Required]
        [Display(Name = "Is Female")]
        public bool IsFemale { get; set; }

        [Required]
        [Display(Name = "Is Potty Trained")]
        public bool IsPottyTrianed { get; set; }

        [Display(Name = "Allergies")]
        public string Allergies { get; set; }

        [Display(Name = "Medicine")]
        public string Medicine { get; set; }

        [Required]
        [Display(Name = "Vaccinations Up To Date")]
        public bool VaccinationsUpToDate { get; set; }

        [Required]
        [Display(Name = "Emergency Contact")]
        public string EmergencyContact { get; set; }

        [Required]
        [Display(Name = "Emergency Contact Phone Number")]
        public string EmergencyContactPhoneNumber { get; set; }

        [Required]
        [Display(Name = "Authorized People For PickUp")]
        public string AuthorizedPeopleForPickUp { get; set; }

        public Int64 ParentID { get; set; }

    }


}
