namespace WILTeam1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Business")]
    public partial class Business
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Product { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Manager { get; set; }

        public int? OwnerId { get; set; }

        public virtual BusinessOwner BusinessOwner { get; set; }
    }
}
