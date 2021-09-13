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
    public class PreConfiguration
    {
        [Fact]
        public void Configure()
        {
            Type[] STANDARDRETURN = new Type[0];
            Mock<IPreconfiguration> MOCK = new Mock<IPreconfiguration>();
            MOCK.Setup(a => a.LoadAssembly()).Returns(STANDARDRETURN);
            var Return = MOCK.Object.LoadAssembly();
            Assert.NotNull(Return);
        }
    }
}
