namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Poster")]
    public partial class Poster
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Link { get; set; }

        public long? Position_Poster_ID { get; set; }
    }
}
