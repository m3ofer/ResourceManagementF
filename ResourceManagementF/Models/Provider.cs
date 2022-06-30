using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResourceManagementF.Models
{
    public class Provider
    {
        public Provider()
        {
            Computerslist = new List<Computer>();
            Printerslist = new List<Printer>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        [DisplayName("Nom de Société")]
        [Required]
        public string CompanyName { get; set; }
        [DisplayName("Adresse")]
        [Required]
        public string Adr { get; set; }
        [DisplayName("gérant")]
        [Required]
        public string Manager { get; set; }
        public List<Computer> Computerslist { get; set; }
        public List<Printer> Printerslist { get; set; }
    }
}