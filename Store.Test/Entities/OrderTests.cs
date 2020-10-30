using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace store.test.Entities
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Dar_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dar_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_seu_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            Assert.Fail();
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido__valido_seu_total_deve_ser_50()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            Assert.Fail();
        }
    }
}