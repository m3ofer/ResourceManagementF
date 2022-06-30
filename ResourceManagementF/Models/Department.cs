using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResourceManagementF.Models
{
    public class Department
    {
        public Department()
        {
            TeachersList = new List<Teacher>();
            AcompDepList = new List<AcompDep>();
            AprintDepList = new List<AprintDep>();
        }

        public int Id { get; set; }
        [DisplayName("Nom de Departement")]
        [Required]
        public string Name { get; set; }
        public string Budget { get; set; }
        public List<Teacher> TeachersList { get; set; }
        public List<AcompDep> AcompDepList { get; set; }
        public List<AprintDep> AprintDepList { get; set; }
    }
}