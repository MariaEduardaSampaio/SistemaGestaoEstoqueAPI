using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; private set; }
        public bool IsAvailable { get; private set; }

        [MaxLength(40, ErrorMessage = "Este campo deve conter no máximo 40 caracteres")]
        public string Name { get; private set; }

        [MaxLength(200, ErrorMessage = "Este campo deve conter no máximo 200 caracteres")]
        public string? Description { get; private set; }

        public decimal Price { get; private set; }
        public decimal WeightPerUnit { get; private set; }
        public int Quantity { get; private set; }
        public DateTime AddedToStockDate { get; private set; } = new();

        public Product(string name, string description, decimal price, decimal weightPerUnit, int quantity)
        {
            IsAvailable = true;
            Name = name;
            Description = description;
            Price = price;
            WeightPerUnit = weightPerUnit;
            Quantity = quantity;
            AddedToStockDate = DateTime.Now;
        }
    }
}
