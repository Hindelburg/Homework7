namespace HW7_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string searched { get; set; }

        public DateTime dateSearched { get; set; }

        [Required]
        [StringLength(128)]
        public string requestorIP { get; set; }

        [Required]
        [StringLength(808)]
        public string requestorAgent { get; set; }
    }
}
