using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace EFreelancer.Entities
{
    public class AdminStaffs
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AdminStaffId { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserLogins UserLogin { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public DateTime DateAdded { get; set; }

        public int Permissions { get; set; }

        public bool RequirePasswordChange { get; set; }

        public string Password { get; set; }
    }
}