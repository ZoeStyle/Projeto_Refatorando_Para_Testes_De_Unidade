using Flunt.Validations;

namespace store.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(product, "product", "Não é permitido colocar pedido nulo")
                .IsLowerThan(0, quantity, "quantity", "A quantidade deve ser maior que zero")
            );
            Product = product;
            Price = Product != null ? product.Price : 0;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }
}