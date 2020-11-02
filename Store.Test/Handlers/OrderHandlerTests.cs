using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using store.Domain.Command;
using store.Domain.Handlers;
using store.Domain.Repositories;
using store.test.Repositories;

namespace store.test.Handlers
{
    [TestClass]
    public class OrderHandlerTests
    {
        private readonly ICustumerRepository _custumerRespository;
        private readonly IDeliveryFreeRepository _deliveryRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderHandlerTests()
        {
            _custumerRespository = new FakeCustumerRepository();
            _deliveryRepository = new FakeDeliveryFreeRepository();
            _discountRepository = new FakeDiscountRepository();
            _orderRepository = new FakeOrderRepository();
            _productRepository = new FakeProductRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_cliente_inexistente_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "1234567891";
            command.ZipCode = "1341108";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            
            var handle = new OrderHandler(
                _custumerRespository,
                _deliveryRepository,
                _discountRepository,
                _orderRepository,
                _productRepository
            );

            handle.Handle(command);

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        [TestCategory("handlers")]
        public void Dado_um_cep_invalido_o_pedido_nao_deve_ser_gerado_normalmente()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "12345678911";
            command.ZipCode = "134110889";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            
            var handle = new OrderHandler(
                _custumerRespository,
                _deliveryRepository,
                _discountRepository,
                _orderRepository,
                _productRepository
            );

            handle.Handle(command);

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        [TestCategory("handlers")]
        public void Dado_um_promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "12345678911";
            command.ZipCode = "134110889";
            command.PromoCode = "123456789";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            
            var handle = new OrderHandler(
                _custumerRespository,
                _deliveryRepository,
                _discountRepository,
                _orderRepository,
                _productRepository
            );

            handle.Handle(command);

            Assert.IsTrue(handle.Valid);
        }

        [TestMethod]
        [TestCategory("handlers")]
        public void Dado_um_pedido_sem_itens_o_mesmo_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "12345678911";
            command.ZipCode = "12345678";
            command.PromoCode = "12345678";
            
            var handle = new OrderHandler(
                _custumerRespository,
                _deliveryRepository,
                _discountRepository,
                _orderRepository,
                _productRepository
            );

            handle.Handle(command);

            Assert.IsTrue(handle.Valid);
        }

        [TestMethod]
        [TestCategory("handlers")]
        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "";
            command.ZipCode = "134110805";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            
            var handle = new OrderHandler(
                _custumerRespository,
                _deliveryRepository,
                _discountRepository,
                _orderRepository,
                _productRepository
            );

            handle.Handle(command);

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        [TestCategory("handlers")]
        public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = "12345678911";
            command.ZipCode = "12345678";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            
            var handle = new OrderHandler(
                _custumerRespository,
                _deliveryRepository,
                _discountRepository,
                _orderRepository,
                _productRepository
            );

            handle.Handle(command);
            
            Assert.IsTrue(handle.Valid);
        }
    }
}