using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ResourceManagementF.Models
{
    public class AcompDep
    {
        public int Id { get; set; }
        [DisplayName("Departement")]
        public Department Deps { get; set; }
        [DisplayName("Computers")] 
        public Computer Comp { get; set; }
        public bool Affecter { get; set; }
        public bool Panne { get; set; }
    }
}