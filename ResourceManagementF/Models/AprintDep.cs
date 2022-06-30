using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ResourceManagementF.Models
{
    public class AprintDep
    {
        public AprintDep()
        {
            MaintenanceServices = new List<MaintenanceService>();
        }
        public int Id { get; set; }
        [DisplayName("Departements")]
        public Department Deps { get; set; }
        [DisplayName("Imprimantes")]
        public Printer Prints { get; set; }
        public bool Affecter { get; set; }
        public bool Panne { get; set; }
        public List<MaintenanceService> MaintenanceServices { get; set; }

    }
}