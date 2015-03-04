using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Domain.Entities
{
    [Table("products")]
    public class Product : Abstract.BaseProduct
    {
        public Product() { }

        public Product(long serialNumber)
        {
            SerialNumber = serialNumber;
            Description = string.Empty;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("serialNumber", TypeName = "bigint")]
        public override long SerialNumber { get; set; }

        [MaxLength(256)]
        [Column("description", TypeName = "nvarchar")]
        public override string Description { get; set; }
    }
}
