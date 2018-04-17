using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Site.Domain.Abstract;
using Site.Domain.Entities;
using Site.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Site.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IVinylRepository> mock = new Mock<IVinylRepository>();
            mock.Setup(m => m.products).Returns(new List<Vinyl>
            {
                new Vinyl { VinylId = 1, Title = "пластинка1" },
                new Vinyl { VinylId = 2, Title = "пластинка2" },
                new Vinyl { VinylId = 3, Title = "пластинка3" },
                new Vinyl { VinylId = 4, Title = "пластинка4" },
                new Vinyl { VinylId = 5, Title = "пластинка5" },
            });
            VinylController controller = new VinylController(mock.Object);
            controller.pageSize = 3;

            IEnumerable<Vinyl> result = (IEnumerable<Vinyl>)controller.List("", 2);

            List<Vinyl> vinyl = result.ToList();
            Assert.IsTrue(vinyl.Count == 2);
            Assert.AreEqual(vinyl[0].Title, "пластинка4");
            Assert.AreEqual(vinyl[1].Title, "пластинка5");

        }
    }
}
