using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discount.Grpc.Entities
{
    [Table("coupon")]
    public class Coupon
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("productName")]
        public string ProductName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("amount")]
        public int Amount { get; set; }
    }
}