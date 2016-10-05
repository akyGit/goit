namespace Homework15
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaleId { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Sum { get; set; }

        public virtual Product Product { get; set; }
    }
}
