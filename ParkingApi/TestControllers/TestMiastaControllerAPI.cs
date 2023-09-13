using BLL.IWorkServices;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace TestControllers
{
    public class TestMiastaControllerAPI
    {
        [Fact]
        public void TestDodajMiasto()
        {
            Mock<IMiastoService> mocMiastoService = new Mock<IMiastoService>();
            List<Miasto> miasta = new List<Miasto>()
            {
                new Miasto { Id = 1, Nazwa = "Katowice", Wojewodztwo = "Śląskie"},
                new Miasto { Id = 2, Nazwa = "Chorzów", Wojewodztwo = "Śląskie"},
                new Miasto { Id = 3, Nazwa = "Bytom", Wojewodztwo = "Śląskie"}
            };
            mocMiastoService.Setup(m => m.GetMiasta())
                .ReturnsAsync(miasta);

            var miastaController = new MiastaController(mocMiastoService.Object);
            var result = miastaController.GetAllMiasta();
            var objectResult = result.Result as OkObjectResult;


            Assert.NotNull(objectResult);
            var resultValue = objectResult.Value;
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
