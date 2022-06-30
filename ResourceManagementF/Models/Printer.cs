using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResourceManagementF.Models
{
    public class Printer
    {
        public Printer()
        {
            APrintList = new List<AprintDep>();
            APrintTList = new List<AprintT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        public string Speed { get; set; }
        public string Resolution { get; set; }
        public List<AprintDep> APrintList { get; set; }
        public List<AprintT> APrintTList { get; set; }

    }
}