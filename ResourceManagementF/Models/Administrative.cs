using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResourceManagementF.Models
{
    public class Administrative
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [DisplayName("Responsable de Resource")]
        public bool Isresp { get; set; }
    }
}