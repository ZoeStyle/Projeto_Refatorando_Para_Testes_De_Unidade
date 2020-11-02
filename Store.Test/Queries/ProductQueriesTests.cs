using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using store.Domain.Entities;
using store.Domain.Queries;

namespace store.test.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private IList<Product> _produts;

        public ProductQueriesTests()
        {
            _produts = new List<Product>();
            _produts.Add(new Product("Porduto 01", 10, true));
            _produts.Add(new Product("Porduto 02", 10, true));
            _produts.Add(new Product("Porduto 03", 10, true));
            _produts.Add(new Product("Porduto 04", 10, false));
            _produts.Add(new Product("Porduto 05", 10, false));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_Consulta_de_produtos_ativos_deve_retornar_3()
        {
            var result = _produts.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_Consulta_de_produtos_inativos_deve_retornar_2()
        {
            var result = _produts.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.AreEqual(result.Count(), 2);
        }
    }
}