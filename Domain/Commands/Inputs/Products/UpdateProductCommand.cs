namespace Domain.Commands.Inputs.Products
{
    public class UpdateProductCommand
    {
        public int Id { get; private set; }
        public bool IsAvailable { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal WeightPerUnit { get; private set; }
        public int Quantity { get; private set; }

        public void Validate()
        {
            if (Name.Length == 0 || Name == null)
                throw new ArgumentException("Nome de produto não pode ser vazio.");

            if (Price <= 0)
                throw new ArgumentException("Preço de produto não pode ser 0 ou negativo.");

            if (WeightPerUnit <= 0)
                throw new ArgumentException("Peso de produto não pode ser 0 ou negativo.");

            if (Quantity < 0)
                throw new ArgumentException("Quantidade do produto disponível em estoque não pode ser negativa.");
        }
    }
}
