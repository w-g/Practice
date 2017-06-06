using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository.Models
{
    [TableName("Product")]
    [PrimaryKey("Id")]
    public class Product : CustomizableEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Code")]
        public string Code { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Size")]
        public string Size { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        // ref_1 : 引用1


    }
}
