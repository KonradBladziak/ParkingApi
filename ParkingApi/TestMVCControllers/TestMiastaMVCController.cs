using DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCControllers
{
    public class TestMiastaMVCController
    {

        [Fact]
        public void TestDodajMiasto() { 
            ParkingBLLMock parkingBLLMock = new ParkingBLLMock();
            MiastaMVCController miastaController = new MiastaMVCController(parkingBLLMock);
            var result = miastaController.DodajMiasto("Test5","Test5");

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Null(viewResult.Model);
            Assert.Equal(2, parkingBLLMock.miasta.Count());
        }

        [Fact]
        public void TestUsunMiasto() {
            ParkingBLLMock parkingBLLMock = new ParkingBLLMock();
            MiastaMVCController miastaController = new MiastaMVCController(parkingBLLMock);
            
            Miasto miasto = parkingBLLMock.miasta.Find(x => x.Nazwa == "Test2");
            var result = miastaController.UsunMiasto(miasto.Id);
            
            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.Null(viewResult.Model);
            Assert.Equal(1, parkingBLLMock.miasta.Count());

        }
    }
}
