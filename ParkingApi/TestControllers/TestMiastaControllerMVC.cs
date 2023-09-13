using BLL.IWorkServices;
using BLL.WorkServices;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControllers
{
    public class TestMiastaControllerMVC
    {

        [Fact]
        public async Task TestIndex()
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

            var result = await miastaController.Index();
            var viewResult = (ViewResult)result;

            Assert.IsType<ViewResult>(viewResult);
            Assert.Equal(miasta, viewResult.ViewData["Miasta"]);
        }

        [Fact]
        public void TestEditMiasto()
        {
            Mock<IMiastoService> mocMiastoService = new Mock<IMiastoService>();

            List<Miasto> miasta = new List<Miasto>()
            {
                new Miasto()
            {
                Id = 1,
                Nazwa = "Katowice",
                Wojewodztwo = "Małopolskie",
                Parkingi = new Collection<Parking> { }
            }
        };
            mocMiastoService.Setup(m => m.GetMiasta())
                .ReturnsAsync(miasta);
            var miastaController = new MiastaController(mocMiastoService.Object);

            int id = 1;

            var miasto = miasta.Find(m => m.Id == id);
            miasto.Wojewodztwo = "Śląskie";
            var result = miastaController.Edit(id, miasto);

            Assert.Equal(miasto, miasta.FirstOrDefault(m => m.Id == id));
        }

    }
}
