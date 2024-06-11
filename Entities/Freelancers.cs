using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFreelancer.Entities
{
    public class Freelancers
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FreelancerId { get; set; }  

        [Required]
        public string Username { get; set; }  

        [Required]
        public string Email { get; set; } 

        [Required] 
        public string PhoneNumber { get; set; }

        [Required]  
        public string Skillsets { get; set; }  

        public string Hobby { get; set; }

        public string Password { get; set; }

        public DateTime DateJoin { get; set; }
    }
}