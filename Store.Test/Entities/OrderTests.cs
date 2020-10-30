using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using store.Domain.Entities;
using store.Domain.Enums;

namespace store.test.Entities
{
    [TestClass]
    public class OrderTests
    {
        private readonly Custumer _custumer = new Custumer("Victor", "regiotimao@gmail.com");
        private readonly Discount _discount = new Discount(0, DateTime.Now);
        private readonly Product _product = new Product("Produto Teste", 10, true);

        [TestMethod]
        [TestCategory("Domain")]
        public void Dar_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var order = new Order(_custumer, 4, _discount);
            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dar_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            var order = new Order(_custumer, 4, _discount);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_seu_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            var order = new Order(_custumer, 4, _discount);
            order.AddItem(_product, 3);
            order.Pay(34);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            var order = new Order(_custumer, 0, _discount);
            order.Cancel();
            Assert.AreEqual(order.Status, EOrderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order (_custumer, 0, null);
            order.AddItem(null, 1);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order (_custumer, 0, null);
            order.AddItem(_product, 0);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido__valido_seu_total_deve_ser_50()
        {
            var order = new Order (_custumer, 0, null);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total() , 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order (_custumer, 0, null);
            order.AddItem(_product, 5);
        }
    }
}