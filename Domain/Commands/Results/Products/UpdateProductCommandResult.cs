namespace Domain.Commands.Results.Products
{
    internal class UpdateProductCommandResult
    {
        public int Id { get; private set; }
        public bool IsAvailable { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal WeightPerUnit { get; private set; }
        public int Quantity { get; private set; }
        public DateTime AddedToStockDate { get; private set; } = new();

        public UpdateProductCommandResult(int id, bool isAvailable, string name, string? description, decimal price, decimal weightPerUnit, int quantity, DateTime addedToStockDate)
        {
            Id = id;
            IsAvailable = isAvailable;
            Name = name;
            Description = description;
            Price = price;
            WeightPerUnit = weightPerUnit;
            Quantity = quantity;
            AddedToStockDate = addedToStockDate;
        }
    }
}
