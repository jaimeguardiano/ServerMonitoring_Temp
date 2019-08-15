using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMysqlCore.Models
{
    public class Servers
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ip_address { get; set; }
    }
}
