
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoodToCode.Extensions;
using GoodToCode.Framework.Repository;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class VentureOptionTests
    {
        /// <summary>
        /// Contact_PersonTests
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public async Task Venture_VentureOption_Get()
        {
            var reader = new EntityReader<VentureOption>();
            var ItemToTest = new VentureOption();

            ItemToTest = reader.GetAll().FirstOrDefaultSafe();
            Assert.IsTrue(ItemToTest != null, "Item constructed and did not fail.");
        }
    }
}
