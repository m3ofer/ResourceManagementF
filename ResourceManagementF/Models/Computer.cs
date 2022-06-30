using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResourceManagementF.Models
{
    public class Computer
    {
        public Computer()
        {
            ACompDepList = new List<AcompDep>();
            ACompTList = new List<AcompT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Code")]
        public int Id { get; set; }
        [DisplayName("Date de livraison")]
        [Required]
        public string DateLivraison { get; set; }
        [DisplayName("durée de garantie")]
        [Required]
        public string Warranty { get; set; }
        [DisplayName("Fournisseur")]
        public Provider ProvidersId { get; set; }
        public string Brand { get; set; }
        public string Cpu { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public string Monitor { get; set; }
        public List<AcompDep> ACompDepList { get; set; }
        public List<AcompT> ACompTList { get; set; }
    
    }
}