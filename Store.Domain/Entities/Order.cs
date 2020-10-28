using System;
using System.Collections.Generic;
using store.Domain.Enums;

namespace store.Domain.Entities
{
    public class Order  : Entity
    {
        public Order(Custumer custumer, decimal deliveryFree, Discount discount)
        {
            Custumer = custumer;
            Date = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0,8);
            Status = EOrderStatus.WaitingPayment;
            DeliveryFree = deliveryFree;
            Discount = discount;
            Items = new List<OrderItem>();
        }

        public Custumer Custumer { get; private set; }
        public DateTime Date { get; private set; }
        public string Number { get; private set; }
        public IList<OrderItem> Items { get; private set; }
        public decimal DeliveryFree { get; private set; }
        public Discount Discount { get; private set; }
        public EOrderStatus Status { get; private set; }

        public void AddItem(Product product, int quantity)
        {
            var item = new OrderItem(product, quantity);
            Items.Add(item);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Total();
            }

            total += DeliveryFree;
            total += Discount != null ? Discount.Value() : 0;

            return total;
        }

        public void Pay (decimal amaount)
        {
            if(amaount == Total())
                this.Status = EOrderStatus.WaitingDelivery;
        }

        public void Cancel ()
        {
            Status = EOrderStatus.Canceled;
        }
    }
}