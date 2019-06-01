namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public long? Product_Category_ID { get; set; }

        public long? MainCategory_ID { get; set; }
    }
}
