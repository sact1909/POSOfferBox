using Moq;
using Moq.Language.Flow;
using POSOfferBox.BL.EngineCore.Abstract;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POSOfferBox.Test
{
    public class TestBase<T> where T : class, IBusinessEngine
    {
        public Mock<IBusinessEngineFactory> businessEngineFactory = new Mock<IBusinessEngineFactory>();
        private Mock<T> methodMock = new Mock<T>();
        public TestBase()
        {
           
        }
        public ISetup<T, Task<TResult>> SetupEngine<TResult>(Expression<Func<T,Task<TResult>>> expresion)
        {
            var result = methodMock.Setup(expresion);
            businessEngineFactory.Setup(a => a.GetBusinessEngine<T>()).Returns(methodMock.Object);
            return result;
        }

        public ISetup<T, TResult> SetupEngine<TResult>(Expression<Func<T, TResult>> expresion)
        {
            var result = methodMock.Setup(expresion);
            businessEngineFactory.Setup(a => a.GetBusinessEngine<T>()).Returns(methodMock.Object);
            return result;
        }

    }
}
