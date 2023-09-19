using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWorld.Data
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}";}
        }

        [MaxLength(15)]
        public string Phone { get; set; }
        public string EGN { get; set; }
        //public string Name { get; set; }
        public string Email { get; set; }
        //public int CatalogId { get; set; }

        //public Catalog MyProperty { get; set; }
    }
}
