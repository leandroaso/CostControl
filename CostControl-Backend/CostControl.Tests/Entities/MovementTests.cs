using CostControl.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CostControl.Tests.Entities
{

    [TestClass]
    public class MovementTests
    {
        private Departament _departament;
        private Employee _employee;
        private Movement _movement;

        public MovementTests()
        {
            _departament = new Departament("Distribution");
            _employee = new Employee("Wellington", _departament);
            _movement = new Movement(_employee, "movement test", 500);
        }

        [TestMethod]
        public void ShouldCreateMovementWhenValid()
        {
            Assert.AreEqual(true, _movement.Valid);
        }
    }
}