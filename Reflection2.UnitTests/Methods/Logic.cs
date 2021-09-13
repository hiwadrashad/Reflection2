using Moq;
using Reflection2.LIB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reflection2.UnitTests.Methods
{
    public class Logic
    {
        [Fact]
        public void GetData()
        {
            Type[] STANDARDRETURN = new Type[0];
            Mock<IPreconfiguration> MOCK = new Mock<IPreconfiguration>();
            MOCK.Setup(a => a.LoadAssembly()).Returns(STANDARDRETURN);
            var Return = MOCK.Object.LoadAssembly();
            Mock<ILogic> MOCK2 = new Mock<ILogic>();
            MOCK2.Setup(a => a.GetData(Return));
            var ex = Record.Exception(() => MOCK2.Object.GetData(Return) );
            Assert.Null(ex);
        }
        [Fact]
        public void AssignData()
        {
            Type[] STANDARDRETURN = new Type[0];
            Mock<IPreconfiguration> MOCK = new Mock<IPreconfiguration>();
            MOCK.Setup(a => a.LoadAssembly()).Returns(STANDARDRETURN);
            var Return = MOCK.Object.LoadAssembly();
            Mock<ILogic> MOCK2 = new Mock<ILogic>();
            MOCK2.Setup(a => a.AssignData(Return));
            var ex = Record.Exception(() => MOCK2.Object.AssignData(Return));
            Assert.Null(ex);
        }
    }
}
