using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using store.Domain.Command.Interfaces;

namespace store.Domain.Command
{
    public class CreateOrderCommand : Notifiable, ICommand
    {
        public CreateOrderCommand()
        {
            Items = new List<CreateOrderItemCommand>();
        }
        public CreateOrderCommand(string custumer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
        {
            Custumer = custumer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
        }

        public string Custumer { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public IList<CreateOrderItemCommand> Items { get; set; }
        
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen(Custumer, 11, "Custumer", "Cliente invalido")
                .HasLen(ZipCode, 8, "ZipCode", "CEP inválido")
            );
        }
    }
}