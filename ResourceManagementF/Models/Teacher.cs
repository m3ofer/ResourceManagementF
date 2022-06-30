using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResourceManagementF.Models
{
    public class Teacher
    {
        public Teacher()
        {
            AcompTeachersLists = new List<AcompT>();
            AprintTeachersLists = new List<AprintT>();
        }

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DisplayName("Mot de pass")]
        public string Password { get; set; }
        [DisplayName("Laboratoire")]
        [Required]
        public string Lab { get; set; }
        [DisplayName("Chef de departement")]
        public bool Ischef { get; set; }
        public Department DepartmentId { get; set; }
        public List<AcompT> AcompTeachersLists { get; set; }
        public List<AprintT> AprintTeachersLists { get; set; }
    }
}