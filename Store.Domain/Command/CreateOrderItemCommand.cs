using System;
using Flunt.Notifications;
using Flunt.Validations;
using store.Domain.Command.Interfaces;

namespace store.Domain.Command
{
    public class CreateOrderItemCommand : Notifiable, ICommand
    {
        public CreateOrderItemCommand(){ }

        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; set; }
        public int Quantity { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen (Product.ToString(), 32, "Product", "Produto invalido")
            .IsGreaterThan(Quantity, 0,"Qauntity", "Quantidade invalida" )
            );
        }
    }
}