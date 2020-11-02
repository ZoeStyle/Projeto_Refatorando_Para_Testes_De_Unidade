using System.Linq;
using Flunt.Notifications;
using store.Domain.Command;
using store.Domain.Command.Interfaces;
using store.Domain.Entities;
using store.Domain.Handlers.interfaces;
using store.Domain.Repositories;
using store.Domain.Utils;

namespace store.Domain.Handlers
{
    public class OrderHandler : Notifiable, IHandler<CreateOrderCommand>
    {
        private readonly ICustumerRepository _custumerRespository;
        private readonly IDeliveryFreeRepository _deliveryRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderHandler(ICustumerRepository custumerRepository, IDeliveryFreeRepository deliveryFreeRepository, IDiscountRepository discountRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _custumerRespository = custumerRepository;
            _deliveryRepository = deliveryFreeRepository;
            _discountRepository = discountRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }


        public ICommandResult Handle(CreateOrderCommand command)
        {
            // Fall fast Validation
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false,"pedido invalido", command.Notifications);
            
            // 1. Recuperar o cliente
            var custumer = _custumerRespository.Get(command.Custumer);

            // 2. Calcular a taxa de entrega
            var deliveryFree = _deliveryRepository.Get(command.ZipCode);

            // 3. Obter cupom desconto
            var discount = _discountRepository.Get(command.PromoCode);

            // 4. Gerar pedido
            var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();
            var order = new Order(custumer, deliveryFree, discount);
            foreach(var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            // 5. Agrupar as notificacoes
            AddNotifications(order.Notifications);

            // 6. Verifica se deu tudo certo
            if(Invalid)
               return new GenericCommandResult(false,"Falha ao gerar o pedido", Notifications);

            // 7. Retorna o resultado
            _orderRepository.Save(order);
            return new GenericCommandResult(true,$"Pedido {order.Number} gerado com sucesso", order); 
        }
    }
}