namespace ISUTechnicalService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockTracking")]
    public partial class StockTracking
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        [Required]
        [StringLength(15)]
        public string Brand { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }
    }
}
