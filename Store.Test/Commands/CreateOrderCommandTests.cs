using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using store.Domain.Command;

namespace store.test.Commands
{
    [TestClass]
    public class CreateOrderCommandTests
    {
        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_Comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Custumer = " ";
            command.ZipCode = "13411080";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.IsTrue(command.Invalid);
        }
        
    }
}