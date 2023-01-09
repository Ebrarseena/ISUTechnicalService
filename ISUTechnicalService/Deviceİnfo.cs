namespace ISUTechnicalService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deviceİnfo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Brand { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Trouble { get; set; }

        public DateTime Date { get; set; }

        public double Price { get; set; }

        public bool Status { get; set; }
    }
}
