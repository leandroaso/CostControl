using CostControl.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CostControl.Tests.Entities
{

    [TestClass]
    public class DepartamentTests
    {
        private Departament _departament;

        public DepartamentTests()
        {
            _departament = new Departament("Distribution");
        }

        [TestMethod]
        public void ShouldCreateDepartamentWhenValid()
        {
            Assert.AreEqual(true, _departament.Valid);
        }
    }
}