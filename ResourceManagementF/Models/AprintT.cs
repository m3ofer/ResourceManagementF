using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ResourceManagementF.Models
{
    public class AprintT
    {
        public AprintT()
        {
            MaintenanceServicesList = new List<MaintenanceService>();
        }
        public int Id { get; set; }
        [DisplayName("Enseignant")]
        public Teacher Profs { get; set; }
        [DisplayName("Impriment")]
        public Printer Printers { get; set; }
        public bool Affecter { get; set; }
        public bool Panne { get; set; }
        public List<MaintenanceService> MaintenanceServicesList { get; set; }
    }
}