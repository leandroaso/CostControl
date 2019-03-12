using CostControl.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CostControl.Tests.Entities
{
    [TestClass]
    public class EmployeeTests
    {
        private Departament _departament;
        private Employee _employee;

        public EmployeeTests()
        {
            _departament = new Departament("Distribution");
            _employee = new Employee("Wellington", _departament);
        }

        [TestMethod]
        public void ShouldCreateEmployeeWhenValid()
        {
            Assert.AreEqual(true, _employee.Valid);
        }
    }
}