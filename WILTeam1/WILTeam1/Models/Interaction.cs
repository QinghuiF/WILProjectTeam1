namespace WILTeam1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Interaction
    {
        [Column(TypeName = "date")]
        [Display(Name = "Date")]
        public DateTime Join_Date { get; set; }

        [Required]
        public string Comment { get; set; }

        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CauseId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Caus Caus { get; set; }
    }
}
