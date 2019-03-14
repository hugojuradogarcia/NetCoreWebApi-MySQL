using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace NetCoreWebApi_MySQL.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Department
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
