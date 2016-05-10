using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.DataModel.Models
{
    [Table("Products")]
    public class ProductInfos
    {
        [Key]
        public string ProductId { get; set; }

        [MaxLength(20)]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ManufactureDate { get; set; }
    }
}
